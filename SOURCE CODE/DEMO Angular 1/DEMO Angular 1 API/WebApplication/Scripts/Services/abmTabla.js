// NEW
'use strict';

app.service('abmTabla', ["$http", function ($http) {
    return {
        obtenerTabla: function (_nameTabla) {
            return $http.get('PagoAutomatico/Parametria/ObtenerTabla', {
                    params: {
                        nameTabla: _nameTabla
                    }
                })
                .then(function successCallback(response) {
                    return response.data;
                });
        },
        obtenerTablaCompleta: function (_nameTabla, success, error) {
            return $http.get('PagoAutomatico/Parametria/ObtenerTablaCompleta', {
                params: {
                    nameTabla: _nameTabla
                }
            }).success(function (response) {
                success(response);

            }).error(function (response) {
                error(response);
            });

        },
        buscarModulos: function (success,error) {
            return $http.get('PagoAutomatico/Parametria/BuscarModulos', {
                params: {
                }
            })
                .success(function (response) {
                success(response);
            }).error(function(response) {
                  error(response);
            });
        },
        buscarTablas: function(_modulo,success, error) {
            return $http.get('PagoAutomatico/Parametria/BuscarTablas', {
                params: {
                    modulo: _modulo
                }
            }).success(function (response) {
                success(response);
                
            }).error(function(response) {
                error(response);
            });

        }
    };
}]);