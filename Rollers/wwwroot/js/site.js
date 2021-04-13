
var signinErrorAlert = $('.form-error-message', $('#sign-in').closest('.tab-pane'))
$('#sign-in-login-input').keyup(function () {
    signinErrorAlert.html("")
    signinErrorAlert.hide();
})
$('#sign-in-pass-input').keyup(function () {
    signinErrorAlert.html("")
    signinErrorAlert.hide();
})
$('#sign-in-first-name-input').keyup(function () {
    signinErrorAlert.html("")
    signinErrorAlert.hide();
})
$('#sign-in-last-name-input').keyup(function () {
    signinErrorAlert.html("")
    signinErrorAlert.hide();
})
$('#sign-in-email-input').keyup(function () {
    signinErrorAlert.html("")
    signinErrorAlert.hide();
})

var loginErrorAlert = $('.form-error-message', $('#log-in').closest('.tab-pane'))
$('#login-input').keyup(function () {
    loginErrorAlert.html("")
    loginErrorAlert.hide();
})
$('#pass-input').keyup(function () {
    loginErrorAlert.html("")
    loginErrorAlert.hide();
})

$('#main-login-button').click(function () {
    var loginInput = $('#login-input')
    var passwordInput = $('#pass-input')

    var signinLoginInput = $('#sign-in-login-input')
    var signinPasswordInput = $('#sign-in-pass-input')
    var signinFirstNameInput = $('#sign-in-first-name-input')
    var signinLastNameInput = $('#sign-in-last-name-input')
    var signinEmailInput = $('#sign-in-email-input')

    var typeOfAction = $('#type-of-action').html();
    if (typeOfAction === "login") {
        var loginModel = {
            Login: loginInput.val(),
            Password: passwordInput.val()
        }

        ajaxHandler.AjaxPOSTJson(
            "api/Authorization/Login",
            loginModel,
            function () {
                document.location.reload();
            },
            function (responseText) {
                var response = JSON.parse(responseText)
                var errorMessage = ''
                if (response.errors !== undefined) {
                    if (response.errors.Login !== undefined) {
                        errorMessage += response.errors.Login + "<br>"
                    }
                    if (response.errors.Password !== undefined) {
                        errorMessage += response.errors.Password + "<br>"
                    }
                }
                loginErrorAlert.html(errorMessage)
                loginErrorAlert.show()
            }
        );
    }
    if (typeOfAction === "signin") {
        var signInModel = {
            Login: signinLoginInput.val(),
            Password: signinPasswordInput.val(),
            FirstName: signinFirstNameInput.val(),
            LastName: signinLastNameInput.val(),
            Email: signinEmailInput.val()
        }

        ajaxHandler.AjaxPOSTJson(
            "api/Authorization/Register",
            signInModel,
            function () {
                document.location.reload();
            },
            function (responseText) {
                var response = JSON.parse(responseText)
                var errorMessage = ''
                if (response.errors !== undefined) {
                    if (response.errors.Login !== undefined) {
                        errorMessage += response.errors.Login + "<br>"
                    }
                    if (response.errors.Password !== undefined) {
                        errorMessage += response.errors.Password + "<br>"
                    }
                    if (response.errors.FirstName !== undefined) {
                        errorMessage += response.errors.FirstName + "<br>"
                    }
                    if (response.errors.LastName !== undefined) {
                        errorMessage += response.errors.LastName + "<br>"
                    }
                    if (response.errors.Email !== undefined) {
                        errorMessage += response.errors.Email + "<br>"
                    }
                }
                signinErrorAlert.html(errorMessage)
                signinErrorAlert.show()
            }
        );
    }
});

$('#main-logout-button').click(function () {
    ajaxHandler.AjaxPOSTJson(
        "api/Authorization/Logout",
        {},
        function () {
            document.location.reload();
        },
        function (responseText) {
            console.log(responseText)
        }
    );
})


$('#log-in-tab').click(function () {
    $('#main-login-button').html("Log in")
    $('#type-of-action').html("login")
})

$('#sign-in-tab').click(function () {
    $('#main-login-button').html("Sign in")
    $('#type-of-action').html("signin")
})

var addlocationErrorAlert = $('#addlocation-form-error-alert')
$('#addlocation-longitude-input').keyup(function () {
    addlocationErrorAlert.html("")
    addlocationErrorAlert.hide();
})
$('#addlocation-latitude-input').keyup(function () {
    addlocationErrorAlert.html("")
    addlocationErrorAlert.hide();
})
$('#addlocation-name-input').keyup(function () {
    addlocationErrorAlert.html("")
    addlocationErrorAlert.hide();
})
$('#addlocation-address-input').keyup(function () {
    addlocationErrorAlert.html("")
    addlocationErrorAlert.hide();
})
$('#addlocation-description-input').keyup(function () {
    addlocationErrorAlert.html("")
    addlocationErrorAlert.hide();
})

$('#add-new-location-popup').on('hidden.bs.modal', function (e) {
    addlocationErrorAlert.html("")
    addlocationErrorAlert.hide();
})
$('#addlocation-submit-button').click(function () {

    var nameInput = $('#addlocation-name-input')
    var addressInput = $('#addlocation-address-input')
    var descInput = $('#addlocation-description-input')
    var userId = $('#user-id')

    var locationModel = {
        Longitude: markerGlobal.getPosition().toJSON().lng,
        Latitude: markerGlobal.getPosition().toJSON().lat,
        LocationName: nameInput.val(),
        Address: addressInput.val(),
        Description: descInput.val(),
        UserId: parseInt(userId.html().trim())
    }

    ajaxHandler.AjaxPOSTJson(
        "api/RollerSkateMapLocations/addrollerskatemaplocation",
        locationModel,
        function () {
            document.location.reload();
        },
        function (responseText) {
            var response = JSON.parse(responseText)
            var errorMessage = ''
            if (response.errors !== undefined) {
                if (response.errors.Longitude !== undefined) {
                    errorMessage += response.errors.Longitude  + "<br>"
                }
                if (response.errors.Latitude !== undefined) {
                    errorMessage += response.errors.Latitude + "<br>"
                }
                if (response.errors.LocationName !== undefined) {
                    errorMessage += response.errors.LocationName + "<br>"
                }
                if (response.errors.Address !== undefined) {
                    errorMessage += response.errors.Address + "<br>"
                }
                if (response.errors.Description !== undefined) {
                    errorMessage += response.errors.Description + "<br>"
                }
            }

            addlocationErrorAlert.html(errorMessage)
            addlocationErrorAlert.show()
        }
    );

    
});

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

var addcommentErrorAlert = $('#addcomment-form-error-alert')
$('#addcomment-input').keyup(function () {
    addcommentErrorAlert.html("")
    addcommentErrorAlert.hide();
})


$('#addcomment-submit-button').click(function () {

    var commentInput = $('#addcomment-input')
    var userId = $('#user-id')
    var rollerSkateMapLocationId = $('#rollerSkateMapLocation-id')

    var locationModel = {
        CommentText: commentInput.val(),
        UserId: parseInt(userId.html().trim()),
        rollerSkateMapLocationId: parseInt(rollerSkateMapLocationId.html())
    }

    ajaxHandler.AjaxPOSTJson(
        "api/Comments/addcomment",
        locationModel,
        function () {
            document.location.reload();
        },
        function (responseText) {
            var response = JSON.parse(responseText)
            var errorMessage = ''
            if (response.errors !== undefined) {
                if (response.errors.CommentText !== undefined) {
                    errorMessage += response.errors.CommentText + "<br>"
                }
            }

            addcommentErrorAlert.html(errorMessage)
            addcommentErrorAlert.show()
        }
    );


});


//-----------------------Edit comment---------------------


function save_edited_comment(commentId, val) {
    var editedComment = {
        Id: parseInt(commentId),
        CommentText: val.val()
    }

    ajaxHandler.AjaxPOSTJson(
        "api/Comments/comment/update",
        editedComment,
        function () {
            document.location.reload();
        },
        function (responseText) {
            console.log(JSON.parse(responseText))
        }
    );
}

////////////////////Delete_comment///////////////////

function delete_this_comment(commentId) {
    var Id = parseInt(commentId)

    ajaxHandler.AjaxPOSTJson(
        "api/Comments/comment/delete/{Id}",
        Id,
        function () {
            document.location.reload();
        },
        function (responseText) {
            console.log(JSON.parse(responseText))
        }
    );
}

function addlikes(commentId) {
    var id = parseInt(commentId)
    ajaxHandler.AjaxPOSTJson(
        "api/Comments/comment/addlike/"+id,
        {},
        function (response) {
            $('#' + id + '-likes-number').html(response)
        },
        function (responseText) {
            console.log(JSON.parse(responseText))
        }
    );
}

function adddislikes(commentId) {
    var id = parseInt(commentId)
    ajaxHandler.AjaxPOSTJson(
        "api/Comments/comment/adddislike/"+id,
        {},
        function (response) {
            $('#' + id + '-dislikes-number').html(response)
        },
        function (responseText) {
            console.log(JSON.parse(responseText))
        }
    );
}