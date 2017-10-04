shipBobApp.config(function ($routeProvider, $locationProvider) {
   
    $routeProvider.
        when('/', {
            templateUrl: '/Pages/Sample.html',
            controller: 'homeController',
        })
        .when('/Orders/:data', {
            templateUrl: '/Pages/ViewOrders.html',
            controller: 'orderController'
        })
        .when('/Orders/', {
            templateUrl: '/Pages/ViewAllOrders.html',
            controller: 'allOrderController'
        })
        
        .when('/CreateOrder/:data', {
            templateUrl: '/Pages/Order.html',
            controller: 'createOrderController'
        })
        .when('/viewUser', {
            templateUrl: '/Pages/viewUsers.html',
            controller: 'homeController'
        });
    
});