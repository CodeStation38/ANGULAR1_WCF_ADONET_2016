'use strict';

app.controller('clienteCtrl', ["$scope", "$rootScope", "$stateParams", "$state", "loading", "cliente", "menu",
    function ($scope, $rootScope, $stateParams, $state, loading, cliente, menu) {
    
    var Init = function () {
        cargarTiposDocumento();
        menu.esconderMenuCliente();
        loading.cerrarLoding();
    };

    var cargarTiposDocumento = function () {
        cliente.cargarTiposDocumento().then(
            function success(data) {
                $scope.tiposDocumento = data;
                $scope.tipoDocumento = data[1].valor;
            }, function onError(data) {
                alert('ERROR');
            });
    };

    $scope.resultados = [];

    $scope.cargarCliente = function (clienteId) {
        cliente.cargarCliente(clienteId, function () {
            $state.go("cliente.adhesionesVigentes", {
                clienteId: clienteId
            });
        });
    };

    $scope.buscarClientes = function () {
        cliente
            .buscarClientes(this.apellido, this.nombre, this.tipoDocumento, this.documento, this.cuenta, this.tarjeta).
        then(
        function success(data) {
            $scope.resultados = data;
            if (data.length == 0)
                alert("Atención: El solicitante no es titular o no existen datos");

        }, function onError(data) {
            alert("ERROR");
        });
    };

    Init();
    
}]);