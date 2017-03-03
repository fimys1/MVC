app.directive('popUpDialog', function (property) {
    return {
        restrict: 'E',
        scope: false,
        templateUrl: '/Partials/entry.html',
        controller: function ($scope, $http) {

            $scope.showpopUpDialog = false;

            $scope.closePopUpDialog = function()
            {
                $scope.showpopUpDialog = false;
            }

            $scope.getEntry = function (id) {
                $scope.numberId = id;
                $http.post(uri2 + '/Entry?id=' + encodeURIComponent(id), id).then(successEntryCallback, errorCallback);
            }

            function successEntryCallback(response) {
                if (response.data) {
                    $scope.Entry = response.data;
                    $scope.showpopUpDialog = true;
                }
                else {
                    $scope.result = "Не верный ID";
                }
            };

            function errorCallback(error) {
                $scope.result = error.status + " Не верный ID";
            };
        }
    }
});