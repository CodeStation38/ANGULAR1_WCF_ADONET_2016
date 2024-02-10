'use strict';
angular.module('coreApp')
.controller('clienteHistoricoAdhesionesCtrl', ["$scope", "$rootScope", "$stateParams", "loading", "cliente", "menu",
    function ($scope, $rootScope, $stateParams, loading, cliente, menu) {

    var Init = function () {
        menu.seleccionar('menuitemHistoricoAdhesiones');
        buscarAdhesionesHistoricas();
        loading.cerrarLoding();
    };

    $scope.adhesiones = [];

    var buscarAdhesionesHistoricas = function () {
        cliente.buscarAdhesionesHistoricas()
            .then(function success(data) {
                $scope.adhesiones = data;
            }, function errorCallback(data) {
                alert('ERROR');
            });
    };

    Init();

}]);