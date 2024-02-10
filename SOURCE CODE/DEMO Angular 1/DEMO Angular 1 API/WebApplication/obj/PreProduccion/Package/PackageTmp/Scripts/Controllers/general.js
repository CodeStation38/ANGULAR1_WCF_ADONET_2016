'use strict';

app.controller('GeneralCtrl', ["$scope", "$state", "$stateParams", "loading", "$rootScope", "$window", function ($scope, $state, $stateParams, loading, $rootScope, $window) {

     $rootScope.linkHacia = function (stateToChange, params, $event) {
          $event.stopPropagation();
          $state.go(stateToChange, params);
      };

    //no muestro el gif del loading
    loading.ready();

    //no muestro el alert
    $scope.alert = {type :'success', msg: 'Change a few things up and try submitting again.'} ;
    loading.readyAlert();

    // no se muetra la lista de usuarios
    $scope.listaUsers = false;

    $scope.cerrarAlert = function(){
        loading.readyAlert();
    }

 }]);
