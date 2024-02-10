'use strict';
app.controller('abmTablasCtrl',
[
        "$scope", "$http", "$modal", "$state", "$stateParams", "loading", "menu", "abmTabla","$filter", "abmTablasFactory",
    function ($scope, $http, $modal, $state, $stateParams, loading, menu, abmTabla, $filter, abmTablasFactory) {


        $scope.gridOptions = {
            data: []
        };
        $scope.validarGrilla = false;

        abmTabla.buscarModulos(function (response) {
            $scope.modulos = response;
        }, function() {
            
        });
        //abmTabla.buscarTablas().then(function (myData) {
        //    $scope.tablas = myData;
        //});;

        $scope.buscarTablas = function (modulo) {
            if (modulo == "") {
                limpiarview();
                $scope.tablas = [];
            } else {


                //  $scope.tablas = [];
                $scope.validarGrilla = false;
                $scope.gridOptions = {
                    data: []
                };
                abmTabla.buscarTablas(modulo, function(response) {
                    $scope.tablas = response;
                }, function() {});
            }
        };

        //$scope.buscarTablas = function (modulo) {
        //abmTabla.buscarTablas(modulo).then(
        //        function success(data) {
        //            $scope.tablas = data;
        //            if (data.length == 0)
        //                alert("Atención: No tienes permisos para modificar las tablas del modulo.");
        //        }, function onError(data) {
        //            alert("ERROR");
        //        });
        //};

        $scope.obtenerTablaCompleta = function (tablacodigoSeleccionada) {
            if (tablacodigoSeleccionada == "") {
                limpiarview();
            }
            else {
                abmTabla.obtenerTablaCompleta(tablacodigoSeleccionada, function (response) {
                    $scope.myData = [];
                    $scope.columnsSelected = [];

                $scope.validarGrilla = true;
                $scope.myData = response.datos;
                $scope.tablasRelacionadas = response.tablasRelacionadas;
                $scope.campos = response.campos;

                
                //$scope.gridOptions.columnDefs = [
            
                //{ field: 'view', displayName: 'Modificar', cellTemplate: '<button type="button" ng-model="row" class="btn btn-warning btn-circle btn-xs" ng-click=""><i class="fa fa-pencil fa-2x"></i></button>' },
                //    { field: 'view', displayName: 'Eliminar', cellTemplate: '<button type="button" ng-model="row" class="btn btn-danger btn-xs" ng-click=""><i class="fa fa-trash-o fa-2x"></i></button>' }
                //];

                //agrego columnas de datos
                response.campos.forEach(function (value) {
                    if (value.tablaFK != null) {
                        response.datos.forEach(function(val) {
                            val[value.etiqueta] = obtenerDescripcion(val[value.etiqueta], value.tablaFK);
                        });
                        $scope.columnsSelected.push({ field: value.etiqueta, displayName: value.etiqueta });
                    }
                    else
                    {
                        $scope.columnsSelected.push({ field: value.etiqueta, displayName: value.etiqueta });
                    }
                });

                    //agrego columna Modificar
          
                if (boolFindByKey(response.campos, 'permiteEdicion', true)) {
                    $scope.columnsSelected.push(
                                        { field: 'view', displayName: 'Modificar', cellTemplate: '<button type="button" ng-model="row" class="btn btn-warning btn-circle btn-xs" ng-click=""><i class="fa fa-pencil fa-2x"></i></button>' }
                        );
                };



                    //agrego columna Eliminar

                $scope.pk = $filter("filter")(response.campos, { "esPk": 1 }, true);

                if (response.tabla.permiteBaja) {
                    $scope.columnsSelected.push(
                    //{ field: 'view', displayName: 'Eliminar', cellTemplate: '<button type="button" ng-model="row" class="btn btn-danger btn-xs" ng-click="eliminarItem(row.entity[{{pk.etiqueta}}], {{pk.nombreCampo}} , {{pk.nombreTabla}})"><i class="fa fa-trash-o fa-2x"></i></button>' }
                    { field: 'view', displayName: 'Eliminar', cellTemplate: '<button type="button" ng-model="row" class="btn btn-danger btn-xs" ng-click="eliminarItem(row.entity.'+$scope.pk[0].etiqueta +')"><i class="fa fa-trash-o fa-2x"></i></button>' }

                        );
                };

                //visualiza boton alta
                if (response.tabla.permiteAlta) {
                    $scope.veralta = true;
                };

                $scope.gridOptions = {
                    data: 'myData',
                    columnDefs: 'columnsSelected'
                //    columnDefs: [
                //    { field: 'view', displayName: 'Modificar', cellTemplate: '<button type="button" ng-model="row" class="btn btn-warning btn-xs" ng-click=""><i class="fa fa-pencil fa-2x"></i></button>' },
                //    { field: 'view', displayName: 'Eliminar', cellTemplate: '<button type="button" ng-model="row" class="btn btn-danger btn-xs" ng-click=""><i class="fa fa-trash-o fa-2x"></i></button>' }
                //]
            };
            }, function(){});
            };
        };

        function boolFindByKey(array, key, value) {
            for (var i = 0; i < array.length; i++) {
                if (array[i][key] === value) {
                    return true;
                }
            }
            return false;
        }

        function limpiarview() {
            $scope.myData = [];
            $scope.gridOptions = {
                data: []
            };
            $scope.gridOptions.columnDefs = [];
            $scope.validarGrilla = false;
            $scope.veralta = false;
        }

        function obtenerDescripcion(id, tabla)
        {
            var result = $filter("filter")($scope.tablasRelacionadas, { "nombre": tabla }, true);
            var result2 = $filter("filter")(result[0].campos, { "pkFK": id }, true)[0].descFK;
            return result2;

        }

        $scope.eliminarItem = function (valorCampo) {
            //$scope.eliminarItem = function (nombreCampo, valorCampo, nombreCampo) {
            var itemD = { nombreCampo: $scope.pk[0].nombreCampo, valorCampo: valorCampo, tabla: $scope.pk[0].nombreTabla };
            abmTablasFactory.setItemD(itemD);
            var modalInstance = $modal.open({
                templateUrl: 'PagoAutomatico/AmbTablas/ModalDelete',
                controller: 'deleteItem',
                windowClass: 'modal',
                animation: true,
                backdrop: "static",
                keyboard: false,
            });

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            };

        };

        $scope.altaItem = function () {
            //$scope.eliminarItem = function (nombreCampo, valorCampo, nombreCampo) {
            //var itemD = { nombreCampo: $scope.pk[0].nombreCampo, valorCampo: valorCampo, tabla: $scope.pk[0].nombreTabla };
            //abmTablasFactory.setItemD(itemD);
            abmTablasFactory.setFormatoCampos($scope.campos);
            abmTablasFactory.setTablasRelacionadas($scope.tablasRelacionadas);
            var modalInstance = $modal.open({
                templateUrl: 'PagoAutomatico/AmbTablas/ModalAM',
                controller: 'amItem',
                windowClass: 'modal',
                animation: true,
                backdrop: "static",
                keyboard: false,
            });

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            };

        };

//$scope.nameTabla = "tm_bco_banco";
        //abmTabla.obtenerTabla($scope.nameTabla).then(function (myData) {
        //    $scope.questions = myData;
        //});;
        //$scope.gridOptions = { data: 'questions' };
    }])
        .controller("deleteItem", ["$scope", "$modalInstance", "abmTablasFactory", function ($scope, $modalInstance, abmTablasFactory) {
            $scope.itemD = abmTablasFactory.getItemD();
            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            };
            $scope.eliminar = function () {
            };


        }])
        .controller("amItem", ["$scope", "$modalInstance", "abmTablasFactory", "$filter", function ($scope, $modalInstance, abmTablasFactory, $filter) {
            $scope.campos = abmTablasFactory.getFormatoCampos();
            $scope.tablasRelacionadas = abmTablasFactory.getTablasRelacionadas();
            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            };
            $scope.alta = function () {
            };

            $scope.obtenerTablaRelacionada = function(tabla) {
            var result = $filter("filter")($scope.tablasRelacionadas, { "nombre": tabla }, true);
            return result[0].campos;
            };


}])