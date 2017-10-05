
shipBobApp.controller('homeController', ['$scope', '$rootScope', '$location', '$http', '$route','filterFilter', function ($scope, $rootScope, $location, $http, $route, filterFilter) {
    $scope.viewby ;
    $scope.oneAtATime = true;
    $scope.userData = [];
    result1 = $http({
        method: 'GET',
        url: '/Home/GetUser',
        headers: {
            "Content-Type": "application/json"
        }
    }).then(function (response) {
        $scope.userData.push(response.data);
    }), (function (responsedata) {
        alert("Error");
    });

    $scope.$watch('lm', function () {
        $scope.lastname = $scope.lm;
    });
    $scope.$watch('firstname', function () {
        $scope.firstname = $scope.firstname;
    });


    $scope.submitUser = function (firstName1, lastName1) {
        if ($scope.firstname == null || $scope.lastname == null) {
            alert("Please Enter First Name and Last Name");
        }
        else if (!(/^[a-zA-Z]*$/.test($scope.firstname)) || !(/^[a-zA-Z]*$/.test($scope.lastname))) {
            alert("Please Enter only Alphabets");
        }
        else {
            $scope.UserDetails = {
                firstName: $scope.firstname,
                lastName: $scope.lastname
            };
            result = $http({
                method: 'POST',
                url: '/Home/CreateUser',
                data: { userDetails: $scope.UserDetails },
                headers: {
                    "Content-Type": "application/json"
                }

            }).then(function (response) {
                alert("User created successfully");
                $route.reload();
            }), (function (response) {
                console.log("Error" + response);
            })

        }

    };

    $scope.getUserDetails = function (index) {

        var data = $scope.userData[0][index].userId;
        $location.path('/Orders/'+data) ;
    }

    $scope.createOrder = function (index) {
        var data = $scope.userData[0][index].userId;
        $location.path('/CreateOrder/' + data);

    }

    $scope.viewby = 3;
    $scope.totalItems = $scope.userData.length;
    console.log($scope.totalItems);
    $scope.currentPage = 4;
    $scope.itemsPerPage = $scope.viewby;

    $scope.setPage = function (pageNo) {
        $scope.currentPage = pageNo;
    };

    $scope.pageChanged = function () {
        console.log('Page changed to: ' + $scope.currentPage);
    };

    $scope.setItemsPerPage = function (num) {
        $scope.itemsPerPage = num;
        $scope.currentPage = 1; //reset to first page
    };
}]);
