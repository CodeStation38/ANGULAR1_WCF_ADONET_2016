'use strict';

app.factory('cliente',["$http","$rootScope", function ($http,$rootScope) {
      return {
          cargarCliente: function (idCliente,success) {
              var modulo = this;
              $http.get('PagoAutomatico/Cliente/BuscarCliente', {
                  params: {
                      idCliente: idCliente
                  }
              })
               .then(function successCallback(response) {
                   modulo.cargarDatosCliente(response.data);
                   success();
               }, function errorCallback(response) {
                   
               });
              
          },
                   
          limpiarCliente: function () {
              this.cliente = undefined;
          },

          cargarDatosCliente: function (unCliente) {
              this.cliente = unCliente;
          },

          cargarTiposDocumento: function(){
              return $http.get('PagoAutomatico/Parametria/BuscarTiposDocumento')
               .then(function successCallback(response) {
                   return response.data;
               });
          },

          buscarClientes: function (apellido, nombre, tipoDocumento, documento, cuenta, tarjeta) {
              return $http.get('PagoAutomatico/Cliente/BuscarClientes', {
                  params: {
                      apellido: apellido,
                      nombre: nombre,
                      tipoDocumento: tipoDocumento,
                      documento: documento,
                      cuenta: cuenta,
                      tarjeta: tarjeta
                  }
              })
               .then(function successCallback(response) {
                   return response.data;
               });
          },

          buscarAdhesiones: function () {
              var factory = this;
              return $http.get('PagoAutomatico/Adhesion/BuscarAdhesiones', {
                  params: {
                      clienteId: factory.cliente.id
                  }
              })
               .then(function successCallback(response) {
                   return response.data;
               });
          },

          buscarAdhesionesHistoricas: function () {
              var factory = this;
              return $http.get('PagoAutomatico/Adhesion/BuscarAdhesionesHistoricas', {
                  params: {
                      clienteId: factory.cliente.id
                  }
              })
               .then(function successCallback(response) {
                   return response.data;
               });
          }


      }
  }]);
