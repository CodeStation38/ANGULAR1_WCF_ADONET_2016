app.directive('datatables', function () {
    return {
        restrict: 'E, A, C',
        link: function (scope, element, attr, parent) {
            $.extend(scope.options, {
                "oLanguage": {
                    "sLengthMenu": "Mostrar _MENU_ registros por página",
                    "sZeroRecords": "No se encontraron resultados",
                    "sInfo": "Mostrando _START_ hasta _END_ de _TOTAL_ registros",
                    "sInfoEmpty": "Mostrando 0 hasta 0 de 0 registros",
                    "sInfoFiltered": "(Filtrado de _MAX_ registros en total)",
                    "sSearch": "Buscar: ",
                    "sEmptyTable": "No se encontraron resultados",
                    "oPaginate": {
                        "sFirst": "Primero",
                        "sLast": "Ultimo",
                        "sNext": "Siguiente",
                        "sPrevious": "Anterior"
                    }
                }
            });

            var dataTable = element.dataTable(scope.options);

            scope.$watch('options.aaData', handleModelUpdates, true);

            function handleModelUpdates(newData) {
                var data = newData || null;
                if (data && newData.length > 0) {
                    dataTable.fnClearTable();
                    dataTable.fnAddData(data);




                    if (attr.rowclick) {

                        dataTable.find("tbody tr").on("click", function (event) {
                            var position = dataTable.fnGetPosition(this);
                            scope.rowclick({ row: dataTable.fnGetData(position), parentScope: scope.$parent });
                        });
                    }



                }
            }
        },
        scope: {
            options: "=",
            rowclick: '&rowclick'
        },
        transclude: false
    };
});