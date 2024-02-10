'use strict';

var app = angular
  .module('coreApp', [
    'ngAnimate',
    'ngAria',
    'ngCookies',
    'ngMessages',
    'ngResource',
    'ngRoute',
    'ngSanitize',
    'ui.router',
    'ngTouch',
    'ui.bootstrap',
    'ngGrid',
    'angular-growl',
    'blockUI',
    'angular.filter'
  ])
app.run([
'$http', "$rootScope", "$state", "$modal", "$location","$filter", function ($http, $rootScope, $state, $modal, $location, $fliter) {
    var path = $location.path().replace("/", "");
    //var teste = new Date();
    //var teste = $filter("formatdate");
    $rootScope.location = path;
    $rootScope.$state = $state;
    $rootScope.showModal = function (titulo, descripcion) {
        $modal.open({
            templateUrl: "Default/AlertModal",
            controller: 'defaultCtrl',
            windowClass: 'modal',
            animation: true,
            size: 'lg',
            backdrop: "static",
            keyboard: false,
            resolve: {
                modal: function () {
                    var modal = {
                        title: titulo,
                        description: descripcion
                    };
                    return modal;
                }
            }
        });
    };
/* Viejo de VirtualDesk - BORRAR
    $rootScope.inArray = Array.prototype.indexOf ?
        function (val, arr) {
            return arr.indexOf(val);
        } :
        function (val, arr) {
            var i = arr.length;
            while (i--) {
                if (arr[i] === val) return i;
            }
            return -1;
        };*/
}
]);
app.config([
"$httpProvider", "$urlRouterProvider", "$sceProvider", "growlProvider", "blockUIConfig",
function ( $httpProvider, $urlRouterProvider, $sceProvider, growlProvider, blockUIConfig) {
    $sceProvider.enabled(false);

    //$('.selectpicker').selectpicker();
    //-------------------------------------------
    //Parche IE, realiza cache y no permite refrescar grillas, cuando se hace ajax por get
    $httpProvider.defaults.cache = false;
    if (!$httpProvider.defaults.headers.get) {
        $httpProvider.defaults.headers.get = {};
    }

    $httpProvider.defaults.headers.get['If-Modified-Since'] = '0';
    //-------------------------------------------

    //Configuración de Mensajes
    growlProvider.globalTimeToLive({ success: 5000, error: -1, warning: 5000, info: 5000 });

    blockUIConfig.requestFilter = function (config) {
        return false;
    };
}]);



