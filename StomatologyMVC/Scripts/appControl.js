app.controller("appContrl", ['$scope', '$http', '$location', 'property', function ($scope, $http, $location, property) {

    Date.prototype.yyyymmdd = function () {
        var mm = this.getMonth() + 1;
        var dd = this.getDate();

        return [(dd > 9 ? '' : '0') + dd + '-',
                (mm > 9 ? '' : '0') + mm + '-',
                this.getFullYear()
        ].join('');
    };

    $scope.date = {
        value: new Date()
    };

    $http.get(uri + "/GetUser").then(successUserCallback, errorCallback);

    function successUserCallback(response) {
        $scope.userinf = response.data;
    };

    function successSendCallback(response) {
        $scope.PostDataResponse = response.data;
        $scope.ClearWindow();
        //$location.path("/" + $scope.PostDataResponse);
        alert('Ваш номер заявки:' + $scope.PostDataResponse);
    };

    function successTimeCallback(response) {
        property.deleteOptions();
        property.setOption({ 'valueHiden': '0', 'valueScren': 'Выберете время' });
        for (nOpt in response.data) {
            property.setOption(response.data[nOpt]);
        }
        $scope.options = property.getOption();
        $scope.selected = property.getOptionSelected();
        //console.log($scope.options);
    };

    function errorCallback(error) {
        $scope.result = error.status;
    };


    $scope.options = property.getOption();
    $scope.selected = property.getOptionSelected();

    $scope.send = function () {
        if ($scope.complaint != undefined) {
            $http.post(uri, { "Time": $scope.selected.valueHiden.toString(), "Complaint": $scope.complaint.toString() })
            .then(successSendCallback, errorCallback);
        }
        else {
            $scope.result = "*Введите жалобу";
        }
    }

    $scope.ClearWindow = function () {
        property.deleteOptions();
        property.setOption({ 'valueHiden': '0', 'valueScren': 'Выберете дату...' });
        $scope.complaint = "";
        $scope.result = "";
        $scope.btnVisibility();
    }

    $scope.btnVisibility = function () {
        if ($scope.options.length > 1
            && $scope.selected.valueHiden != 0) {
            $scope.sendBtn = { visibility: 'visible' };
        }
        else {
            $scope.sendBtn = { visibility: 'hidden' };
        }
    }

    $scope.getOptions = function (date) {
        var asd = date.yyyymmdd();
        if (date.yyyymmdd() != null) {
            $http.get(uri + "/Time?date=" + encodeURIComponent(date.yyyymmdd()))
                .then(successTimeCallback, errorCallback);
        }
    };
}]);