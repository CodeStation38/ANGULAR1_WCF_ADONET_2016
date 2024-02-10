'use strict';

app.factory('adhesion', ["$http", "$rootScope", function ($http, $rootScope) {
    return {
        cargarAdhesion: function (adhesionId, success) {
            var modulo = this;
            $http.get('PagoAutomatico/Adhesion/BuscarAdhesion', {
                params: {
                    adhesionId: adhesionId
                }
            })
             .then(function successCallback(response) {
                 modulo.cargarDatosAdhesion(response.data);
                 success();
             }, function errorCallback(response) {

             });

        },

        limpiarAdhesion: function () {
            this.adhesion = undefined;
        },

        cargarDatosAdhesion: function (unaAdhesion) {
            this.adhesion = unaAdhesion;
        }

    }
}]);
