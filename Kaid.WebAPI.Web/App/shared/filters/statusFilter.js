
(function (app) {
    app.filter('statusFilter', function() {
        return function (input)
        { return (input) ? 'Enable' : 'Disable'; }
    });
    
})(angular.module('kaid.common'));