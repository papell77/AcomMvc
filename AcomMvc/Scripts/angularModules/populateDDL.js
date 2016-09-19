var app = angular.module('popDDL', []);

app.controller('countyController', function ($scope, $http) {

        $http.get('/Admin/counties/GetJson').then(function (response) {
            $scope.counties = response.data;
        }, function (response) {
            $scope.error = "Errore: " + response.data;
        });
    //};

});

app.controller('agentController', function ($scope, $http) {
        $http.get('/Admin/agents/GetJson').then(function (response) {
            $scope.agents = response.data;
        }, function (response) {
            $scope.error = "Errore: " + response.data;
        });
    //};
});

app.controller('canalController', function ($scope, $http) {
        $http.get('/Admin/canals/GetJson').then(function (response) {
            $scope.canals = response.data;
        }, function (response) {
            $scope.error = "Errore: " + response.data;
        });
    //};
});


app.controller('cityController', function ($scope, $http) {
        $http.get('/Admin/cities/GetJson').then(function (response) {
            $scope.cities = response.data;
        }, function (response) {
            $scope.error = "Errore: " + response.data;
        })
    //};

    $scope.GetCitiesByCountyId = function (id) {
        $http.get('/Admin/cities/GetJsonByCountyId/' + id).then(function (response) {
            $scope.cities = response.data;
        }, function (response) {
            $scope.error = "Errore: " + response.data;
        });
    };

});

app.controller('userController', function ($scope, $http) {
    $http.get('/Manage/GetJsonUsers').then(function (response) {
        $scope.users = response.data;
    }, function (response) {
        $scope.error = "Errore: " + response.data;
    });
});

