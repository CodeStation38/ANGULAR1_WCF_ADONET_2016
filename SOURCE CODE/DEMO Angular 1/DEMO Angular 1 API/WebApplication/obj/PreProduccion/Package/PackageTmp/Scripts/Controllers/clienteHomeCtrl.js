'use strict';
angular.module('coreApp')
.controller('clienteHomeCtrl', [ "$scope", "$stateParams", "$state", "loading", "cliente", "adhesion", "menu",
    function ($scope, $stateParams, $state, loading, cliente, adhesion, menu) {
  
   
    var Init = function () {
        menu.seleccionar('menuitemAdhesionesVigentes');
        buscarAdhesiones($stateParams.clienteId);
        loading.cerrarLoding();
    };

    $scope.adhesiones = [];

    $scope.irConAdhesion = function (unaAdhesion, $event, state, params) {
        $event.stopPropagation();
        adhesion.cargarAdhesion(unaAdhesion.numero, function success() {
            $state.go(state, params);
        })
    };

    $scope.linkStopDebit = function (unaAdhesion,$event) {

        if (!unaAdhesion.aplicaStopDebit) {
            alert('Las Adhesiones de tipo Puntual no permiten Stop Debit');
        }
        else {
            if (!unaAdhesion.tieneStopDebit) {
                $scope.irConAdhesion(unaAdhesion, $event, "adhesion.stopDebitAlta");
            } else {
                $scope.irConAdhesion(unaAdhesion, $event, "adhesion.stopDebitBaja");
            }
            
        }

    };

    var buscarAdhesiones = function (clienteId) {
        cliente.buscarAdhesiones(clienteId)
            .then(function success(data) {
                $scope.adhesiones = data;
            }, function errorCallback(data) {
                alert('ERROR');
            });
    };

    Init();

}]);