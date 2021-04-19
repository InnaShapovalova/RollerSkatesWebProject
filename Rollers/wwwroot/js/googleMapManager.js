let map;
var markerGlobal = undefined;


function getAddressByPosition(lat, lng) {
    var locationModel = {
        Latitude: lat,
        Longitude: lng
    }

    ajaxHandler.AjaxPOSTJson(
        "api/map/getaddressbyposition",
        locationModel,
        function (response) {
            $('#addlocation-address-input').val(response)
        },
        function (responseText) {
            var response = JSON.parse(responseText)
            console.log(response)
        }
    );
}

// Adds a marker to the map and push to the array.
function addMarker(location) {
    const marker = new google.maps.Marker({
        position: location,
        map: map,
    });
    if(markerGlobal !== undefined)
        markerGlobal.setMap(null)
    markerGlobal = marker;
    getAddressByPosition(markerGlobal.getPosition().toJSON().lat, markerGlobal.getPosition().toJSON().lng)
    console.log(markerGlobal.getPosition().toJSON())
    map.setCenter(location);
}

function initAddLocationMap () {
    map = new google.maps.Map(document.getElementById("map"), {
        zoom: 15,
        center: { lat: 48.292079, lng: 25.935837 },
        mapTypeId: "terrain",
    });

    locationButton = initButton();
    map.controls[google.maps.ControlPosition.TOP_CENTER].push(locationButton);

    locationButton.addEventListener("click", () => {
        // Try HTML5 geolocation.
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(
                (position) => {
                    const pos = {
                        lat: position.coords.latitude,
                        lng: position.coords.longitude,
                    };

                    addMarker(pos);
                }
            );
        } 
    }); 

    // This event listener will call addMarker() when the map is clicked.
    map.addListener("click", (event) => {
        addMarker(event.latLng);
    });
    // Adds a marker at the center of the map.
}
function initButton() {
    const locationButton = document.createElement("button");
    locationButton.textContent = "Pan to Current Location";
    locationButton.class = "btn btn-light border-dark mt-2"
    locationButton.classList.add("custom-map-control-button");

    return locationButton;
}