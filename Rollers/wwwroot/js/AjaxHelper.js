var ajaxHandler = {
    VirtualRoot: $('#app-body').attr('data-approot') === undefined ? '/' : $('#app-body').attr('data-approot'),
    AjaxGETObject: function (apiUrl, apiData, successCallback, errorCallback) {
        jQuery.ajax({
            type: 'GET',
            url: ajaxHandler.VirtualRoot + apiUrl,
            data: apiData,
            success: function (response) {
                if (successCallback) {
                    successCallback(response);
                }
            },
            error: function (obj, msg) {
                if (errorCallback) {
                    errorCallback(obj, msg);
                }
            }
        });
    },
    AjaxPOSTJson: function (apiUrl, apiData, successCallback, errorCallback) {
        $.ajax({
            type: 'POST',
            url: ajaxHandler.VirtualRoot + apiUrl,
            data: JSON.stringify(apiData),
            dataType: 'json',
            contentType: 'application/json',
            success: function (response) {
                if (successCallback) {
                    successCallback(response);
                }
            },
            error: function (obj, msg) {
                if (errorCallback) {
                    errorCallback(obj, msg);
                }
            }
        });
    },
};

