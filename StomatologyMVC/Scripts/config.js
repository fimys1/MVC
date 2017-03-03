app.config(['$locationProvider', '$routeProvider', function ($locationProvider, $routeProvider) {
    $locationProvider.hashPrefix('');
    $routeProvider.when('/', {
        templateUrl: '/Partials/application.html',
        controller: 'ApplicationContrl'
    })
    $routeProvider.when('/entrys', {
        templateUrl: '/Partials/Entrys.html',
        controller: 'EntrysContrl'
    });
    $routeProvider.otherwise({
        redirectTo:'/'
    })
}]);