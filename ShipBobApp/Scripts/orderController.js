shipBobApp.controller('orderController', ['$scope', '$rootScope', '$http', 'userDataShared', '$routeParams', '$location','$route', function ($scope, $rootScope, $http, userDataShared, routeParams, $location, $route) {
    $scope.states = ['Alabama', 'Alaska', 'Arizona', 'Arkansas', 'California', 'Colorado', 'Connecticut', 'Delaware', 'Florida', 'Georgia', 'Hawaii', 'Idaho', 'Illinois', 'Indiana', 'Iowa', 'Kansas', 'Kentucky', 'Louisiana', 'Maine', 'Maryland', 'Massachusetts', 'Michigan', 'Minnesota', 'Mississippi', 'Missouri', 'Montana', 'Nebraska', 'Nevada', 'New Hampshire', 'New Jersey', 'New Mexico', 'New York', 'North Dakota', 'North Carolina', 'Ohio', 'Oklahoma', 'Oregon', 'Pennsylvania', 'Rhode Island', 'South Carolina', 'South Dakota', 'Tennessee', 'Texas', 'Utah', 'Vermont', 'Virginia', 'Washington', 'West Virginia', 'Wisconsin', 'Wyoming'];

    $scope.userId= routeParams.data;
    var data = routeParams.data;
    $scope.UserDetails = {
        userId: $scope.userId
    };
    
    $scope.orderData;
    result1 = $http({
        method: 'POST',
        url: '/Order/GetOrder',
        data: { userDetails : $scope.UserDetails },
        headers: {
            "Content-Type": "application/json"
        }
    }).then(function (response) {
        $scope.orderData = response.data;
    }), (function (responsedata) {
        });
        $scope.update = function (orders) {
            if (confirm("Are you sure about updating the order?")) {
                console.log(orders);
                $scope.orderDetails = orders;
                result = $http({
                    method: 'POST',
                    url: '/Order/UpdateOrder',
                    data: { orderDetails: $scope.orderDetails }
                }).then(function (response) {
                }), (function (errorResponse) {
                });
            }
        };

        $scope.delete = function (orders) {
            if (confirm("Are you sure about deleting order?")) {
                result = $http({
                    method: 'POST',
                    url: '/Order/DeleteOrder',
                    data: { trackingId: orders.trackingId }
                }).then(function (response) {
                    $route.reload();
                }), (function (errorResponse) {
                });
            }
            
        };

        $scope.createOrder = function () {
            $location.path('/CreateOrder/' + data) 
        }

   
}]);