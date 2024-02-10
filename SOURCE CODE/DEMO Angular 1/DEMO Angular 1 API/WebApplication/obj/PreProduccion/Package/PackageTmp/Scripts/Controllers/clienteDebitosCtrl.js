'use strict';
angular.module('coreApp')
.controller('clienteDebitosCtrl',
        ["$scope", "$rootScope", "$stateParams", "loading", "debitos",
    function ($scope, $rootScope, $stateParams, loading, debitos) {
    var Init = function () {
        var origen = $stateParams.origen;
        var idAdhe = $stateParams.adhesionId;
         if (origen == "historicos")
         {
             $scope.pagina_origen = "Adhesiones Históricas - Consulta de Adhesión Nro. " + idAdhe;
         }
         if (origen == "vigente")
         {
             $scope.pagina_origen = "Adhesiones Vigentes - Consulta de Adhesión Nro. " + idAdhe;
         }
         buscarDebitos($stateParams.adhesionId);
        loading.cerrarLoding();
    };

    var buscarDebitos = function (adhesionId) {
        //
        debitos.buscarDebitos(adhesionId).then(function success(data) {
            
            $scope.Adhesiondebitos = data;
        });

        
    };

    Init();

}]);