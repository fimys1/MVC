app.controller("EntrysContrl", ['$scope', '$http', 'property', function ($scope, $http, property) {

    $scope.show = function (e) {
        var id = $(e.target).data('id');
        $scope.getEntry(id);
    }

    $http.get(uri2 + '/Entrys').then(successEntrysCallback, errorCallback);

    function successEntrysCallback(response) {
        $scope.appAll = response.data;
    };

    function errorCallback(error) {
        $scope.result = error.status;
    };
}]);