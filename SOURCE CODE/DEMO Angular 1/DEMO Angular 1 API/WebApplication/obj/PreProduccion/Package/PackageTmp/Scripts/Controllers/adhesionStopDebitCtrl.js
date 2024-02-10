'use strict';
app.controller('adhesionStopDebitAltaCtrl',
    ["$scope", "$rootScope", "growl", "adhesion", "debitos", "cuentaBancaria",
        function ($scope, $rootScope, growl, adhesion, debitos, cuentaBancaria) {
    $scope.titulo = "Alta";
    $scope.boton = "Confirmar Stop Debit";

    $rootScope.getAdhesion = function () {
        return adhesion.adhesion;
    }

    $scope.altaStopDebit = function (oAdhesion) {
        alert('WORK IN PROGRESS');
    }

    var InitScope = function () {

        var hayDebitoEnCurso = ($scope.debitoEnCurso.estadoDebito == 'R' || $scope.debitoEnCurso.estadodebito == 'E')
        
        var d = new Date($scope.debitoEnCurso.fechaVencimiento_especifica);
 
        var m = d.getMonth() + 1
        m = m >= 12 ? m - 12 : m;
        d.setMonth(m);
        
        $scope.proximoVencimiento = d.toLocaleDateString("es-AR");

        if (hayDebitoEnCurso) {
            growl.warning("El debito se encuentra en curso. El Stop Debit aplicará para el vencimiento siguiente ( " + $scope.proximoVencimiento + " )", { ttl:-1,disableCountDown: true });
        }
        
    }
    var Init = function () {
        debitos.buscarUltimoDebitoEnCurso(adhesion.adhesion.numero)
            .then(
            function success(data) {
                $scope.debitoEnCurso = data;
                InitScope();
            }, function onError(data) {
                alert('Error:' + data + '');
            });
        cuentaBancaria.buscarCuentaSegunAdhesion(adhesion.adhesion.numero)
            .then(
            function success(data) {
                $scope.cuentaBancaria = data;
            }, function onError(data) {
                alert('Error:' + data + '');
            });
    }

    Init();

}]);