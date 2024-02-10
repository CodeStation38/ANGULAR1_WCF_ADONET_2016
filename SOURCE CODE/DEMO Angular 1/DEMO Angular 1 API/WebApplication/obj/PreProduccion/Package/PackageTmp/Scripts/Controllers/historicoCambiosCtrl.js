'use strict';
app.controller('historicoCambiosCtrl', ["$scope", "historicoCambios",
    function ($scope, historicoCambios) {

    historicoCambios.init($scope);

    $scope.buscarCambios = function () {
        historicoCambios
            .buscarCambios($scope.desde, $scope.hasta).
        then(
        function success(data) {
            console.log(data);
            $scope.resultados = data;
        }, function onError(data) {
            alert("ERROR");
        });
    };

}]);