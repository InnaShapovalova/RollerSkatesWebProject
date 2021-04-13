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
}

function initAddLocationMap () {
    const chernivtsi = { lat: 48.288750322671135, lng: 25.936233767576702 };
    map = new google.maps.Map(document.getElementById("map"), {
        zoom: 15,
        center: chernivtsi,
        mapTypeId: "terrain",
    });
    // This event listener will call addMarker() when the map is clicked.
    map.addListener("click", (event) => {
        addMarker(event.latLng);
    });
    // Adds a marker at the center of the map.
    addMarker(chernivtsi);
}