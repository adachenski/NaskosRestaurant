$(document).ready(function () {
    var loginLink = $("a[id='loginLink']");
    loginLink.attr({ "href": "#", "data-toggle": "modal", "data-target": "#ModalLogin" });

    $("#loginform").submit(function (event) {
        if ($("#loginform").valid()) {
            var username = $("#Email").val();
            var password = $("#Password").val();
            var rememberme = $("#RememberMe").val();
            var antiForgeryToken = ModalLogin.Views.Common.getAntiForgeryValue();

            ModalLogin.Identity.LoginIntoStd(username, password, rememberme, antiForgeryToken, ModalLogin.Views.LoginModal.loginSuccess, ModalLogin.Views.LoginModal.loginFailure);
        }
        return false;
    });

    $("#ModalLogin").on("hidden.bs.modal", function (e) {
        ModalLogin.Views.LoginModal.resetLoginForm();
    });

    //TODO alle Referenzen auf Form controls bezogen auf form, um Doppeldeutigkeiten zu vermeiden.
    $("#ModalLogin").on("shown.bs.modal", function (e) {
        $("#Email").focus();
    });

});

var Sample = Sample || {};
Sample.Web = Sample.Web || {};
ModalLogin = ModalLogin || {};
ModalLogin.Views = ModalLogin.Views || {}

ModalLogin.Views.Common = {
    getAntiForgeryValue: function () {
        return $('input[name="__RequestVerificationToken"]').val();
    }
}

ModalLogin.Views.LoginModal = {
    resetLoginForm: function () {
        $("#loginform").get(0).reset();
        $("#alertBox").css("display", "none");
    },

    loginFailure: function (message) {
        var alertBox = $("#alertBox");
        alertBox.html(message);
        alertBox.css("display", "block");
    },

    loginSuccess: function () {
        window.location.href = window.location.href;
    }
}


ModalLogin.Identity = {
    LoginIntoStd: function (username, password, rememberme, antiForgeryToken, successCallback, failureCallback) {
        var data = { "__RequestVerificationToken": antiForgeryToken, "username": username, "password": password, "rememberme": rememberme };

        $.ajax({
            url: "/Account/LoginJson",
            type: "POST",
            data: data
        })
        .done(function (loginSuccessful) {
            if (loginSuccessful) {
                successCallback();
            }
            else {
                failureCallback("Invalid login attempt.");
            }
        })
        .fail(function (jqxhr, textStatus, errorThrown) {
            failureCallback(errorThrown);
        });
    }
}
