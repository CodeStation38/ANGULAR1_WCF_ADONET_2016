'use strict';
app.service('debitos',["$http", function ($http) {
      return {
          buscarDebitos: function (adhesionId) {
              return $http.get('PagoAutomatico/Adhesion/BuscarDebitos', {
                  params: {
                      adhId: adhesionId
                  }
              })
               .then(function successCallback(response) {
                   return response.data;
               });
          },
          buscarUltimoDebitoEnCurso: function (adhesionId) {
              
              return $http.get('PagoAutomatico/Adhesion/BuscarUltimoDebitoEnCurso', {
                  params: {
                      adhesionId: adhesionId
                  }
              })
               .then(function successCallback(response) {
                   return response.data;
               });
          }
      }
  }]);
