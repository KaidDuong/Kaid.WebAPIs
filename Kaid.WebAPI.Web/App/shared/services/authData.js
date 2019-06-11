(function (app) {
    'use strist';
    app.factory('authData',
        [
            function () {
                var authDataFactory = {};

                var authentication = {
                    IsAuthenticated: false,
                    userName: ""
                };

                authDataFactory.authenticationData = authentication;

                return authDataFactory;
            }
        ]);
})(angular.module('kaid.common'));