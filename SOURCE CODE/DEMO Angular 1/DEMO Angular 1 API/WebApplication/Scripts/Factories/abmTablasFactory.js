'use strict';

app.factory('abmTablasFactory', function () {
    var itemD = {};
// ReSharper disable once AssignedValueIsNeverUsed
    var formatoTablaCampos = {};
    var tablasRelacionadas = {};
    var registro = {};
    //$scope.banco.codigo = codigo;
    //$scope.banco.descripcion = descripcion;

    return {
        setItemD: function(data) {
            itemD = data;
        },
        getItemD: function() {
            return itemD;
        },

        setFormatoCampos: function (campos) {
            formatoTablaCampos = campos;
    },
        getFormatoCampos: function () {
            return formatoTablaCampos;
        },

        setTablasRelacionadas: function (_tablasRelacionadas) {
            tablasRelacionadas = _tablasRelacionadas;
    },
    getTablasRelacionadas: function () {
        return tablasRelacionadas;
    },
    setDatos: function (_registro) {
        registro = _registro;
    },
    getDatos: function () {
        return registro;
    }
    };





});
