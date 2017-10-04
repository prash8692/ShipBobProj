var shipBobApp = angular.module('shipBobApp', ['ngRoute', 'ngResource', 'ui.bootstrap', "xeditable"]);

shipBobApp.factory('userDataShared', function () {
    return {};
});

shipBobApp.filter('startFrom', function () {
    return function (input, start) {
        if (input) {
            start = +start;
            return input.slice(start);
        }
        return [];
    };
});

