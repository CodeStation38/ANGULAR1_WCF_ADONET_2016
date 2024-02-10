'use strict';
app.service('historicoCambios', ["$http","cliente","adhesion", function ($http,cliente,adhesion) {
    return {
        init: function(scope){
            scope.resultados = [];

            scope.openDesde = function ($event) {
                $event.preventDefault();
                $event.stopPropagation();

                scope.openedDesde = true;
            };

            scope.openHasta = function ($event) {
                $event.preventDefault();
                $event.stopPropagation();

                scope.openedHasta = true;
            };

            scope.getAdhesion = function () {
                return adhesion.adhesion;
            }
        },

        buscarCambios: function (desde, hasta) {
            return $http.get('PagoAutomatico/HistoricoCambios/Buscar', {
                params: {
                    clienteId: cliente.cliente.id,
                    desde: desde,
                    hasta: hasta,
                    adhesionId: adhesion.adhesion.numero
                }
            }).then(
            function success(response) {
                return response.data;
            });
        }
    }
}]);
