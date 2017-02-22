app.config(['$locationProvider', '$routeProvider', function ($locationProvider, $routeProvider) {
    $locationProvider.hashPrefix('');
    $routeProvider.when('/', {
        templateUrl: '/Partials/app.html',
        controller: 'appContrl'
    })
    $routeProvider.when('/allApp', {
        templateUrl: '/Partials/allApp.html',
        controller: 'allContrl'
    });
    $routeProvider.otherwise({
        redirectTo:'/'
    })
}]);