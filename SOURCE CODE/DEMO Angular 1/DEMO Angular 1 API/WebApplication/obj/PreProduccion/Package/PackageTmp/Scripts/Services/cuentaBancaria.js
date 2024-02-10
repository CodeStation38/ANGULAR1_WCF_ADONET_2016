'use strict';
app.service('cuentaBancaria', ["$http",function ($http) {
    return {
        buscarCuentaSegunAdhesion: function (adhesionId) {
            return $http.get('PagoAutomatico/Cliente/BuscarCuentaSegunAdhesion', {
                params: {
                    idAdhesion: adhesionId
                }
            })
             .then(function successCallback(response) {
                 return response.data;
             });
        }
    }
}]);
