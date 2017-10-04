shipBobApp.controller('allOrderController', ['$scope', '$routeParams', '$http', '$location','$route', function ($scope, $routeParams, $http, $location, $route) {
    console.log("AllORdersController");
    $http({
        method: 'GET',
        url: '/Order/GetAllOrders',
        headers: {
            "Content-Type": "application/json"
        }
    }).then(function (response) {
        $scope.orderData = response.data;
    }), (function (responsedata) {
        console.log("Error");
        });
    $scope.update = function (orders) {
        $scope.orderDetails = orders;
        result = $http({
            method: 'POST',
            url: '/Order/UpdateOrder',
            data: { orderDetails: $scope.orderDetails }
        }).then(function (response) {
        }), (function (errorResponse) {
        });
    };

    $scope.delete = function (orders) {
        result = $http({
            method: 'POST',
            url: '/Order/DeleteOrder',
            data: { trackingId: orders.trackingId }
        }).then(function (response) {
            $route.reload();
        }), (function (errorResponse) {
        });
    };
}]);