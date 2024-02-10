// NEW
'use strict';

angular.module('coreApp')
  .factory('altaPagoAutomatico', ["$http", function ($http) {
      return {
          buscarTiposDeAdhesion: function () {
              return $http.get('PagoAutomatico/Parametria/BuscarTiposAdhesion', {
              })
               .then(function successCallback(response) {
                   return response.data;
               });
          },

          buscarTiposDeMonto: function () {
              return $http.get('PagoAutomatico/Parametria/BuscarTiposMonto', {
              })
               .then(function successCallback(response) {
                   return response.data;
               });
          },

          buscarTiposDeCuenta: function () {
              return $http.get('PagoAutomatico/Parametria/BuscarTiposCuenta', {
              })
               .then(function successCallback(response) {
                   return response.data;
               });
          },

          buscarListadoDeBancos: function () {
              return $http.get('PagoAutomatico/Parametria/BuscarBancos', {
              })
               .then(function successCallback(response) {
                   return response.data;
               });
          },

          buscarCuentasDelCliente: function (nro_cuenta_cliente) {
              return $http.get('PagoAutomatico/Cliente/BuscarCuentas', {
                  params: {
                      idNroCuentaCliente: nro_cuenta_cliente
                  }
              })
               .then(function successCallback(response) {
                   return response.data;
               });
          },

          chequearSiPermitoAdhesion: function (ctaNro_cliente) {
              return $http.get('PagoAutomatico/Cliente/BuscarAdhesionRecurrenteVigente', {
                  params: {
                      ctaClienteNro: ctaNro_cliente
                  }
              })
               .then(function successCallback(response) {
                   return response.data;
               });
          },


          buscarFechaDebitoPorVencimiento: function (clienteFechaVenc) {

              return $http.get('PagoAutomatico/Cliente/BuscarFechaDebitoPorVencimiento', {
                  params: {
                      clienteFechaVencimiento: clienteFechaVenc
                  }
              })
               .then(function successCallback(response) {
                   return response.data;
               }, function onError(response) { alert("Error"); console.log(response);});
          },

          buscarFechaDebitoPorFechaEspecAdheRecur: function (clienteFechaDebito, diaElegido) {
              return $http.get('PagoAutomatico/Cliente/BuscarFechaDebitoPorFechaEspecAdheRecu', {
                  params: {
                      clienteFDeb: clienteFechaDebito,
                      diaElegidoNuevaAdhe: diaElegido
                  }
              })
               .then(function successCallback(response) {
                   return response.data;
               });
          },


          buscarFechaDebitoPorFechaEspecAdhePuntual: function (fechaEspecificaElegida) {
              return $http.get('PagoAutomatico/Cliente/BuscarFechaDebitoPorFechaEspecAdhePuntual', {
                  params: {
                      fechaElegida: fechaEspecificaElegida,
                   }
              })
               .then(function successCallback(response) {
                   return response.data;
               });
          },


          

      }
  }]);