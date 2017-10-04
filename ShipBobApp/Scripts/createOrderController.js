shipBobApp.controller('createOrderController', ['$scope', '$routeParams', '$http', '$location', function ($scope, $routeParams, $http, $location) {
    
  
    var data = $routeParams.data;
    $scope.$watch('trackingId', function () {
        $scope.trackingId = $scope.trackingId;
    });
    $scope.$watch('name', function () {
        $scope.name = $scope.name;
    });
    $scope.$watch('street', function () {
        $scope.street = $scope.street;
    });
    $scope.$watch('address', function () {
        $scope.address = $scope.address;
    });
    $scope.$watch('city', function () {
        $scope.city = $scope.city;
        
    });
    $scope.$watch('states', function () {
        $scope.state = $scope.states;
    });

    $scope.$watch('zipCode', function () {
        $scope.zipcode = $scope.zipCode;
    });

    $scope.addOrder = function () {


        if ($scope.trackingId == null || $scope.state == null || $scope.zipCode == null || $scope.city == null || $scope.name == null || $scope.address == null) {
            alert("Please Enter the Required Fields");
        }

        else if (!(/^[0-9]+$/.test($scope.zipcode))) {
            alert("Please Enter only number for Zip Code")
        }
        else {
            $scope.orderDetails = {
                trackingId: $scope.trackingId,
                name: $scope.name,
                street: $scope.street,
                address: $scope.address,
                city: $scope.city,
                state: $scope.state,
                zipCode: $scope.zipcode,
                userId: data
            };
            console.log($scope.orderDetails);
            result = $http({
                method: 'POST',
                url: '/Order/CretaeOrder',
                data: { orderDetails: $scope.orderDetails },
                headers: {
                    "Content-Type": "application/json"
                }

            }).then(function (response) {
                $location.path("/Orders/" + data);
                

            }), (function (response) {
                console.log("Error" + response);
            });
        }

    }

}]);
