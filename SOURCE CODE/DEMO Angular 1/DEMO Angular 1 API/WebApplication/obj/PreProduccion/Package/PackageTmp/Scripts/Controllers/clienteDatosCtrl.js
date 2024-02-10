'use strict';
angular.module('coreApp')
.controller('clienteDatosCtrl', ["$rootScope", "cliente" ,function ($rootScope, cliente) {
    $rootScope.getCliente = function () {
        return cliente.cliente;
    }
}]);