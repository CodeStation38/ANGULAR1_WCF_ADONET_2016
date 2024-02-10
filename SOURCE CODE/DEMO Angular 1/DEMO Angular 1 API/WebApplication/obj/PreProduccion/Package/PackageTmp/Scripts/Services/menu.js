'use strict';

app.factory('menu', ["$rootScope", function ($rootScope) {
      return {
          esconderMenuCliente: function () {
              //Si el menú está activo, lo cierra
              if ($('#menuCliente').hasClass('sb-active')) {
                  $('.sb-toggle-right').trigger('click');
              }
          },

          seleccionar: function (elementoId) {
              var elemento = $('#' + elementoId);
              $('#nav-accordion').find('.hidden-menu-item').each(function (i) {
                  $(this).removeClass('hidden-menu-item');
              });
              $('#nav-accordion').find('.active').each(function (i) {
                  $(this).removeClass('active');
              });
              $('#nav-accordion').find('.sub').each(function (i) {
                  $(this).css('display','none');
              });
              var padreSubMenu = elemento.closest('.sub-menu');
              if (padreSubMenu) {
                  padreSubMenu.each(function (i) {
                      $(this).find('a').first().addClass('active');
                  });
                  elemento.closest('.sub').css('display', 'block');
              };
              elemento.addClass('active');
          }

      }
  }]);
