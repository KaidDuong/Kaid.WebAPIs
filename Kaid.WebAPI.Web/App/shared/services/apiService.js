/// <reference path="../../../assets/admin/libs/angular/angular.js" />


(function (app) {
    app.factory('apiService', apiService);

    apiService.$inject = ['$http','notificationService','authenticationService'];

    function apiService($http,notificationService,authenticationService) {
        return {
            get: get,
            post: post,
            put: put,
            remove: remove
        };
        function get(url, params, success, failure) {
            authenticationService.sethHeader();
            $http.get(url, params).then(
                function (result) {
                    success(result);
                },
                function (error) {
                    failure(error)
                    
                });
        }
        function post(url, data, success, failure) {
            authenticationService.sethHeader();
            $http.post(url, data)
                .then(function (result)
                {
                success(result);
                },
                function (error)
                {
                    if (error.status === '401') {
                        notificationService.displayError('Authenticate is required!!');
                    } else if (failure != null) {
                        failure(error);
                    }
                });
        }
        function put(url, data, success, failure) {
            authenticationService.sethHeader();
            $http.put(url, data)
                .then
                (
                function (result)
                {
                    success(result);
                },
                function (error)
                {
                    if (error.status === 401) {
                        notificationService.displayError('Authenticate is requied!!');
                    }
                    else if (failure != null) {
                        failure(error);
                    }
                }
                );
        }

        function remove(url, data, success, failure) {
            authenticationService.sethHeader();
            $http.delete(url, data)
                .then
                (
                function (result) {
                    success(result);
                },
                function (error) {
                    if (error.status === 401) {
                        notificationService.displayError('Authenticate is requied!!');
                    }
                    else if (failure != null) {
                        failure(error);
                    }
                }
                );
        }
    }

})(angular.module('kaid.common'));
