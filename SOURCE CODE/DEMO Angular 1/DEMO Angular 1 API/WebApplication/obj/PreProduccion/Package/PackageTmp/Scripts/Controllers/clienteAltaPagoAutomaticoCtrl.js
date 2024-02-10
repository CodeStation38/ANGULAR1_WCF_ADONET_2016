// NEW
'use strict';
angular.module('coreApp')
.controller('clienteAltaPagoAutomaticoCtrl',["$state", "$scope","$filter", "$rootScope", "loading", "altaPagoAutomatico", "cliente","growl", "$modal", 
    function ($state, $scope, $filter, $rootScope, loading, altaPagoAutomatico, cliente,growl, $modal) {


    //$scope.ExisteAdhesionVigenteRecurrente = false;
    $scope.pasoNro = 1;

    $scope.TipoAdhesion_ReglaDeNegocioOk = 1;
    $scope.FechaDeDebito_ReglaDeNegocioOk = 1;
    $scope.MontoADebitar_ReglaDeNegocioOk = 1;

    $scope.permitoPasarAPagina2 = false;
    $scope.permitoPasarAPagina3 = false;
    
    $scope.pagoautomatico = { tipoAdhesion: "", tipoFechaDebito: "", fechaDebito: "", tipoMonto: "", diaEspecificoDebito: "", montoDebitoEspecifico: "", cuil: "", banco: "", cbu: "", fecha2: "" };

    var Init = function () {
        $scope.pagoautomatico.btnpaso2 = true;  // disabled boton 2
        $scope.pagoautomatico.btnpaso3 = true;  // disabled boton 3

        $scope.pagoautomatico.tipoFechaDebitoBool = false;

        //$state.go("cliente.altaPagoAutomatico.Paso1"); // no llamo a cambiar a paso porque de entrada no valido nada
        P1_buscarTiposAdhesion();
        P1_buscarTiposMonto();
        P2_buscarTiposCuenta();
        P2_buscarBancos();
        P2_buscarCuentasDelCliente();
        loading.cerrarLoding();
    };


        
    $scope.ChequeoSiPermitoPasarAPagina3 = function () {
        $scope.permitoPasarAPagina3 = false;

        // si no hay cuentas revienta porque no entiende que es el codigo (SOLUCIONAR ESE PROBLEMA)
        if ($scope.pagoautomatico.cuentasDelUsuario.codigo == null || $scope.pagoautomatico.cuentasDelUsuario.codigo == "") {
            $scope.MostrarMensaje(18, 0);
            return;
        }
        if ($scope.pagoautomatico.mismoTitular == null || $scope.pagoautomatico.mismoTitular == "") {
            $scope.MostrarMensaje(19, 0);
            return;
        }
        else
        {
            if ($scope.pagoautomatico.mismoTitular == "No")
            {
                // revisar que se haya cargado nombre y nro de dni del titular
                if ($scope.pagoautomatico.nombreTitularCBU == null || $scope.pagoautomatico.nombreTitularCBU == "")
                {
                    $scope.MostrarMensaje(20, 0);
                    return;
                }
                if ($scope.pagoautomatico.DNITitularCBU==null || $scope.pagoautomatico.DNITitularCBU=="")
                {
                    $scope.MostrarMensaje(21, 0);
                    return;
                }
            }
        }
        if ($scope.pagoautomatico.cuil == null || $scope.pagoautomatico.cuil == "")
        {
            $scope.MostrarMensaje(22, 0);
            return;
        }
        if ($scope.pagoautomatico.tipoCuenta.codigo == null || $scope.pagoautomatico.tipoCuenta.codigo == "")
        {
            $scope.MostrarMensaje(23, 0);
            return;
        }


        if ($scope.pagoautomatico.banco.codigo == null || $scope.pagoautomatico.banco.codigo == "")
        {
            $scope.MostrarMensaje(24, 0);
            return;
        }
        if ($scope.pagoautomatico.cbu == null || $scope.pagoautomatico.cbu == "")
        {
            $scope.MostrarMensaje(25, 0);
            return;
        }

    };

    $scope.ChequeoSiPermitoPasarAPagina2 = function () {
        $scope.permitoPasarAPagina2 = false;
        // validacion de que no se viole ninguna regla de negocio
        if ($scope.TipoAdhesion_ReglaDeNegocioOk == 0)
        {
            $scope.MostrarMensaje($scope.ErrorNro, 0);
            return;
        }
        if ($scope.FechaDeDebito_ReglaDeNegocioOk == 0)
        {
            $scope.MostrarMensaje($scope.ErrorNro, 0);
            return;
        }
        if($scope.MontoADebitar_ReglaDeNegocioOk == 0)
        {
            $scope.MostrarMensaje($scope.ErrorNro, 0);
            return;
        }

        // validacion de que haya datos cargados
        if ($scope.pagoautomatico.tipoAdhesion.codigo == null || $scope.pagoautomatico.tipoAdhesion.codigo == "")
        {
            $scope.MostrarMensaje(12, 0);
            return;
        }
        else // se cargó tipo de adhesion, pregunto por fecha de debito
        {
            if ($scope.pagoautomatico.tipoFechaDebito == null || $scope.pagoautomatico.tipoFechaDebito == "") {
                $scope.MostrarMensaje(13, 0);
                return;
            }
            else  // se cargo fecha de debito
            {
                if($scope.pagoautomatico.tipoFechaDebito == "F")  
                {
                    if ($scope.pagoautomatico.tipoAdhesion.codigo == "R")
                    {
                        if ($scope.pagoautomatico.diaEspecificoDebito == null || $scope.pagoautomatico.diaEspecificoDebito == "") // reviso que se haya cargado el dia especifico, revisar que sea numerico
                        {
                            $scope.MostrarMensaje(14, 0);
                            return;
                        }
                    }
                    else  // es una adhesion puntual con fecha de debito especifica
                    {
                        if ($scope.pagoautomatico.fechaEspecifica == null || $scope.pagoautomatico.fechaEspecifica == "")
                        {
                            $scope.MostrarMensaje(15, 0);
                            return;
                        }
                    }
                    
                }
                //una vez cargada fecha debito y el día especifico o la fecha especifica pregunto por Monto a debitar
                if($scope.pagoautomatico.tipoMonto.codigo == null || $scope.pagoautomatico.tipoMonto.codigo == "")
                {
                    $scope.MostrarMensaje(16, 0);
                    return;
                }
                else // se cargo el monto a debitar
                {
                    if($scope.pagoautomatico.tipoMonto.codigo=="F")
                    {
                        if ($scope.pagoautomatico.montoDebitoEspecifico == null || $scope.pagoautomatico.montoDebitoEspecifico == "")  // o no es numerico
                        {
                            $scope.MostrarMensaje(17, 0);
                            return;
                        }
                    }
                    // se cargo todo bien
                    $scope.permitoPasarAPagina2 = true;
                }
            }
        }
    };


    var P1_buscarTiposAdhesion = function () {
        altaPagoAutomatico.buscarTiposDeAdhesion().then(function success(data) {
            $scope.tiposAdhesion = data;
         //   $scope.pagoautomatico.tipoAdhesion = data[0];
        });
    };

    var P1_buscarTiposMonto = function () {
        altaPagoAutomatico.buscarTiposDeMonto().then(function success(data) {
            $scope.tiposMonto = data;
        });
    };

    var P2_buscarTiposCuenta = function () {
        altaPagoAutomatico.buscarTiposDeCuenta().then(function success(data) {
            $scope.tiposCuenta = data;
        });
    };

    var P2_buscarBancos = function () {
        altaPagoAutomatico.buscarListadoDeBancos().then(function success(data) {
            $scope.bancos = data;
        });
    };

    var P2_buscarCuentasDelCliente = function () {
        var ctaNro = "ABC123";
        altaPagoAutomatico.buscarCuentasDelCliente(ctaNro).then(function success(data) {
            $scope.cuentasBancarias = data;
        });
    };


    $scope.CambiarAPaso = function (nroPaso) {
        //chequeo de que se haya cargado todo lo necesario de la pagina1, si todo está bien voy a la pagina 2
        switch($scope.pasoNro)
        {
            case 1:
                if (nroPaso == 1) return;                   // ya estoy en el paso 1, no hago nada
                $scope.ChequeoSiPermitoPasarAPagina2();
                if ($scope.permitoPasarAPagina2)
                {
                    $scope.pagoautomatico.btnpaso2 = false;
                    $scope.pasoNro = nroPaso;
                    $state.go("cliente.altaPagoAutomatico.Paso" + nroPaso + ""); 
                }
                break;
            case 2:
                switch (nroPaso)
                {
                    case 1:  // vuelvo al paso 1
                        $scope.pasoNro = nroPaso;
                        $state.go("cliente.altaPagoAutomatico.Paso" + nroPaso + "");
                        break;
                    case 2: // ya estoy en el 2, no hago nada
                        return;
                        break;
                    case 3:  // chequeo si pued pasar al paso 3
                        $scope.ChequeoSiPermitoPasarAPagina3();
                        if ($scope.permitoPasarAPagina3)
                        {
                            $scope.pagoautomatico.btnpaso3 = false;  // activa botón 3
                            $scope.pasoNro = nroPaso;
                            $state.go("cliente.altaPagoAutomatico.Paso" + nroPaso + "");
                        }
                        break;
                }
        }
    };


    $scope.InhabilitarControlesSiguientes = function (index) {
        switch(index)
        {
            case 1:
                $scope.pagoautomatico.tipoFechaDebitoBool = true;
                $scope.pagoautomatico.tipoMontoBool = true;
                break;
            case 2:
                $scope.pagoautomatico.tipoMontoBool = true;
                break;
        }

    }


    $scope.HabilitarControlesSiguientes = function (index) {
        switch (index) {
            case 1:
                $scope.pagoautomatico.tipoFechaDebitoBool = false;
                $scope.pagoautomatico.tipoMontoBool = false;
                break;
            case 2:
                $scope.pagoautomatico.tipoMontoBool = false;
                break;
        }
    };


    


    $scope.P1_ChequearSiPermitoAdhesionPorTipo = function () {   // descomentar los valores hardcodeados y tomarlos del objeto cliente

        var ctaClienteNro = "ABCD1234";                 //cliente.cliente.ctaClienteNro;
        var clienteEnMora = false;                      //cliente.cliente.clienteEnMora;
        var diasMoraP = 40;                             //cliente.cliente.diasMoraP;
        var diasMoraR = 50;                             //cliente.cliente.diasMoraR;

        
        $scope.pagoautomatico.tipoFechaDebito = "";
        $scope.pagoautomatico.tipoMonto = "";
        if ($scope.pagoautomatico.tipoAdhesion.codigo == 'R') {
            if (clienteEnMora) {
                $scope.MostrarMensaje(1, diasMoraR);  // diasMoraR tendria que estar en el scope para que si accedo desde el boton al siguiente paso me muestre el mensaje correcto
                $scope.InhabilitarControlesSiguientes(1);
                $scope.TipoAdhesion_ReglaDeNegocioOk = 0;
                $scope.ErrorNro = 1;
                return;
            }

            altaPagoAutomatico.chequearSiPermitoAdhesion(ctaClienteNro).then(function success(data) {  // chequea si ya existe adhesión vigente recurrente
                $scope.ExisteAdhesionVigenteRecurrente = data;
                if ($scope.ExisteAdhesionVigenteRecurrente == 1) // dejar en 1   (1 si ya tiene una adhesion vig rec y 0 si no)
                {
                    $scope.MostrarMensaje(2, 0);
                    $scope.InhabilitarControlesSiguientes(1);
                    $scope.TipoAdhesion_ReglaDeNegocioOk = 0;
                    $scope.ErrorNro = 2;
                }
                else {
                    //$scope.HabilitarSiguiente(1);
                    $scope.HabilitarControlesSiguientes(1);
                    $scope.TipoAdhesion_ReglaDeNegocioOk = 1;
                }
            });
        }
        if ($scope.pagoautomatico.tipoAdhesion.codigo == 'P')  // revisar toda esta parte
        {  
            if (clienteEnMora == true)
            {
                $scope.MostrarMensaje(3, 0);
                $scope.InhabilitarControlesSiguientes(1);
                $scope.TipoAdhesion_ReglaDeNegocioOk = 0;
                $scope.ErrorNro = 3;
            }
            else
            {
                $scope.HabilitarControlesSiguientes(1);
                $scope.TipoAdhesion_ReglaDeNegocioOk = 1;
            }
        }
    };







    $scope.MostrarMensaje = function (cod, param) {
        switch (cod) {
            case 1:
                
                $scope.showModal("Error", "La cuenta posee más de " + param + " días de mora y no admite una adhesión a Pago Automático");
                break;
            case 2:
                $scope.showModal("Error", "Ya existe una adhesión recurrente para esta cuenta");
                break;
            case 3:
                $scope.showModal("Error", "La situación de la cuenta no admite una adhesión  a Pago Automático");
                break;
            case 4:
                $scope.showModal("Alerta", "El débito se realizará en el vencimiento " + param + " debido a la cercanía del vencimiento más próximo. Recuerde abonar su resumen de cuenta de este vencimiento por otro medio.");
                break;
            case 5:
                $scope.showModal("Alerta", "El débito se realizará en el vencimiento " + param + " debido a la cercanía del vencimiento más próximo. Si lo que desea es pagar su vencimiento más cercano, coloque una fecha específica");
                break;
            case 6:
                $scope.showModal("Error", "La fecha de débito debe estar comprendida entre la fecha de cierre y de vencimiento");
                break;
            case 7:
                $scope.showModal("Alerta", "El primer débito se realizará en la fecha " + param + ". Si desea abonar su vencimiento actual realice además un pago puntual");
                break;
            case 8:
                $scope.showModal("Alerta", "El primer débito se realizará en la fecha " + param);
                break;
            case 9:
                $scope.showModal("Error", "La fecha de débito debe estar comprendida entre la fecha de cierre y de vencimiento");
                break;
            case 10:
                $scope.showModal("Error", "La fecha de pago seleccionada debe ser mayor a " + param + " días hábiles a partir hoy");
                break;
            case 11:
                $scope.showModal("Error","Esta cuenta no permite adherirse al Pago Mínimo");
                break;
            case 12:
                $scope.showModal("Error", "Falta cargar tipo de adhesión");
                break;
            case 13:
                $scope.showModal("Error", "Falta cargar Fecha de Débito");
                break;
            case 14:
                $scope.showModal("Error", "Falta cargar Día Específico");
                break;
            case 15:
                $scope.showModal("Error", "Falta cargar Fecha Específica");
                break;
            case 16:
                $scope.showModal("Error", "Falta seleccionar el Monto a Debitar");
                break;
            case 17:
                $scope.showModal("Error", "Falta cargar el Monto a Debitar");
                break;
            case 18:
                $scope.showModal("Error", "Falta seleccionar una cuenta existente");
                break;
            case 19:
                $scope.showModal("Error", "Falta indicar titularidad");
                break;
            case 20:
                $scope.showModal("Error", "Falta indicar el nombre del titular");
                break;
            case 21:
                $scope.showModal("Error", "Falta indicar el DNI del titular");
                break;
            case 22:
                $scope.showModal("Error", "Falta indicar el CUIL");
                break;
            case 23:
                $scope.showModal("Error", "Falta indicar el tipo de cuenta");
                break;
            case 24:
                $scope.showModal("Error", "Falta indicar el Banco");
                break;
            case 25:
                $scope.showModal("Error", "Falta indicar el CBU");
                break;
        }
    };


    $scope.P1_ChequearFechaDebito = function () {
        $scope.pagoautomatico.tipoMonto = "";
        if ($scope.pagoautomatico.tipoFechaDebito == "V") {
            $scope.P1_ChequearFechaDebitoPorVencimiento();
        }
        if ($scope.pagoautomatico.tipoFechaDebito == "F") {
            $scope.P1_ChequearFechaDebitoPorFechaEspecifica();
        }
    };


    // no hago diferencia si el tipo de adhesion es puntual o recurrente
    // ya que lo que hay que hacer es lo mismo, solo varia mensaje que se presenta al usuario 
    $scope.P1_ChequearFechaDebitoPorVencimiento = function () {

        var clienteFechaVencimiento = "2016-02-22"; //cliente.cliente.FechaVencimiento;
        var siguienteVencimiento = "2016-03-26"; //cliente.cliente.SiguienteVencimiento;

        altaPagoAutomatico.buscarFechaDebitoPorVencimiento(clienteFechaVencimiento)
            .then(function success(data) {
                $scope.objFechaDeb = data;
                $scope.pagoautomatico.fechaDebito = $scope.objFechaDeb.FechaDebito; // $filter('date')($scope.objFechaDeb.FechaDebito, 'yyyy/MM/dd');

                if ($scope.pagoautomatico.tipoAdhesion.codigo == "R")  //adhesion Recurrente, fecha vencimiento
                {  
                    if ($scope.objFechaDeb.EntraMesSiguiente == 1)
                    {
                        $scope.MostrarMensaje(4, $scope.objFechaDeb.FechaDebito);
                    }
                    // DIA = null ;
                    // TIPO_FECHA = $scope.pagoautomatico.tipoFechaDebito; // ES IGUAL A "V";
                    // FECHA_DEBITO = $scope.objFechaDeb.FechaDebito ;
                    // FECHA_DB_ESTIMA = $scope.objFechaDeb.FechaDebito ;
                }
                if ($scope.pagoautomatico.tipoAdhesion.codigo == "P")
                {
                    if ($scope.objFechaDeb.EntraMesSiguiente == 1) {
                        $scope.SetearTipoFechaDesdeModal("El débito se realizará en el vencimiento " + siguienteVencimiento + " debido a la cercanía del vencimiento más próximo. Si lo que desea es pagar su vencimiento más cercano, indique una fecha específica");
                    }

                    // TIPO_FECHA = $scope.pagoautomatico.tipoFechaDebito; // ES IGUAL A "V";
                    // FECHA_DEBITO = $scope.objFechaDeb.FechaDebito ;
                    // FECHA_DB_ESTIMA = $scope.objFechaDeb.FechaDebito ;

                }
            }, function onError(data) {
                alert("ERROR");
            }
        );
    };


    //para tipo adhesion Recurrente y Fecha debito igual a fecha especifica
    $scope.P1_ChequearDiaEspecifico = function () {
        var clienteTipoCuenta = "R";                    //cliente.cliente.TipoCuenta;
        var diaVto = 5;                                //cliente.cliente.DiaVto   o fecha Vto y obtener el dia
        var diaCierre = 25;                              //cliente.cliente.DiaCierre o fecha cierre y obtener el dia
        var clienteFechaDebito = "2016-02-15";          //cliente.cliente.FechaVencimiento;

        //FECHA = null
        // TIPO_FECHA = "D"  // NO USAR $scope.pagoautomatico.tipoFechaDebito porque solo puede tomar los valores ya que no los estoy cargando desde la tabla

        if ($scope.pagoautomatico.diaEspecificoDebito == null || $scope.pagoautomatico.diaEspecificoDebito == "")
        {
            $scope.MostrarMensaje(14, 0);
            return;
        }

        if (clienteTipoCuenta == "R")
        {
            if (diaVto > diaCierre)  // cierre y vto en el mismo mes
            {
                if ($scope.pagoautomatico.diaEspecificoDebito < diaCierre || $scope.pagoautomatico.diaEspecificoDebito > diaVto)  // no debo permitir avanzar porque está fuera de rango 
                {
                    $scope.MostrarMensaje(6, 0);     
                    $scope.pagoautomatico.diaEspecificoDebito = "";
                    $scope.FechaDeDebito_ReglaDeNegocioOk = 0;
                    $scope.ErrorNro = 6;
                    return;
                }
                else
                {
                    $scope.FechaDeDebito_ReglaDeNegocioOk = 1; // debo permitir avanzar porque está dentro del rango 
                }
            }
            else    
            {
                if (!(($scope.pagoautomatico.diaEspecificoDebito > diaCierre || $scope.pagoautomatico.diaEspecificoDebito < diaVto) && $scope.pagoautomatico.diaEspecificoDebito < 28))
                {
                    $scope.MostrarMensaje(6, 0);     // la fecha debe estar entre f de cierre y f de venc.
                    $scope.FechaDeDebito_ReglaDeNegocioOk = 0;  // no debo permitir avanzar porque está fuera de rango 
                    $scope.ErrorNro = 6;
                    return;
                }
            }
        }

        var diaNro = $scope.pagoautomatico.diaEspecificoDebito;
        altaPagoAutomatico.buscarFechaDebitoPorFechaEspecAdheRecur(clienteFechaDebito, diaNro).then(function success(data) {
            $scope.objFechaDeb = data;
            $scope.pagoautomatico.fechaDebito = $scope.objFechaDeb.FechaDebito;     // fecha_debito
            $scope.pagoautomatico.fecha2 = $scope.objFechaDeb.Fecha2;               // fecha_db_estima

            // FECHA_DEBITO = $scope.pagoautomatico.fechaDebito O  FECHA_DEBITO = $scope.objFechaDeb.FechaDebito; 
            // FECHA_DB_ESTIMA =$scope.objFechaDeb.Fecha2;

            if ($scope.objFechaDeb.EntraMesSiguiente == 1)
            {
                $scope.MostrarMensaje(7, $scope.objFechaDeb.Fecha2); 
            }
            else
            {
                $scope.MostrarMensaje(8, $scope.objFechaDeb.Fecha2); 
            }
        });

    };


    $scope.P1_ChequearFechaDebitoPorFechaEspecifica = function () {
        // verificar que haya cargado el dia  (podría estar cargado de antemano si es que se cargo y luego se modifico el 
        //combo de tipo de adhesión), sino se llama a P1_ChequearDiaEspecífico en el lostfocus del campo
        if ($scope.pagoautomatico.tipoAdhesion.codigo == "R")
        {
            if ($scope.pagoautomatico.diaEspecificoDebito != null && $scope.pagoautomatico.diaEspecificoDebito != "")
            {
                $scope.P1_ChequearDiaEspecifico();
            }
        }
        if ($scope.pagoautomatico.tipoAdhesion.codigo == "P") {  // validaciones de adhesión puntual
            if ($scope.pagoautomatico.fechaEspecifica != null && $scope.pagoautomatico.fechaEspecifica != "")
            {
                $scope.P1_ChequearFechaEspecifica();
            }
        }
        
    };


    $scope.P1_ChequearFechaEspecifica = function () {
        var clienteTipoCuenta = "R";                //cliente.cliente.TipoCuenta;
        var fechaCierre = "2016-02-10";            // cliente.cliente.FechaCierre
        var fechaVencimiento = "2016-02-25";       // cliente.cliente.FechaVencimiento

        $scope.pagoautomatico.fechaEspecifica = $filter('formatdate')($scope.pagoautomatico.fechaEspecifica, 'YYYY-MM-DD');
        var fechaEspecificaElegida = $scope.pagoautomatico.fechaEspecifica; // $filter('formatdate')($scope.pagoautomatico.fechaEspecifica,'YYYY-MM-DD'); //$scope.pagoautomatico.fechaEspecifica;
        
        if (clienteTipoCuenta == "R")
        {
            if (fechaEspecificaElegida < fechaCierre || fechaEspecificaElegida > fechaVencimiento)
            {
                $scope.MostrarMensaje(9, 0); 
                $scope.FechaDeDebito_ReglaDeNegocioOk = 0;  
                $scope.ErrorNro = 9;
                return;
            }
            else
            {
                $scope.FechaDeDebito_ReglaDeNegocioOk = 1;
            }
        }

        altaPagoAutomatico.buscarFechaDebitoPorFechaEspecAdhePuntual(fechaEspecificaElegida).then(function success(data) {
            $scope.objFechaDeb = data;

            if ($scope.objFechaDeb.CambiarFecha == 1)
            {
                $scope.MostrarMensaje(10, $scope.objFechaDeb.DiasHabiles);
                $scope.FechaDeDebito_ReglaDeNegocioOk = 0;
                $scope.ErrorNro = 10;
            }
            else
            {
                $scope.FechaDeDebito_ReglaDeNegocioOk = 1;
                // FECHA_DEBITO = PROXIMO VENCIMIENTO // viene con los datos del cliente
                // FECHA_DB_ESTIMA = fechaEspecificaElegida
            }

        });
    };

    $scope.P1_ChequearMontoADebitar = function () {
        var clienteTipoCuenta = "R";                      //cliente.cliente.TipoCuenta;

        switch($scope.pagoautomatico.tipoMonto.codigo)
        {
            case "F":
                $scope.MontoADebitar_ReglaDeNegocioOk = 1;
                // TIPO_MONTO = $scope.pagoautomatico.tipoMonto.codigo
                break;
            case "M":
                if (clienteTipoCuenta != "R")
                {
                    $scope.pagoautomatico.btnpaso2 = true;   // disable boton 2
                    $scope.MostrarMensaje(11, 0);
                    $scope.MontoADebitar_ReglaDeNegocioOk = 0;
                    $scope.ErrorNro = 11;
                }
                else
                {
                    $scope.pagoautomatico.btnpaso2 = false;
                    $scope.MontoADebitar_ReglaDeNegocioOk = 1;
                    // MONTO = "";
                    // TIPO_MONTO = $scope.pagoautomatico.tipoMonto.codigo;
                }
                break;
            case "T":
                $scope.pagoautomatico.btnpaso2 = false;
                $scope.MontoADebitar_ReglaDeNegocioOk = 1;
                // MONTO = "";
                // TIPO_MONTO = $scope.pagoautomatico.tipoMonto.codigo;
                break;
        }


    };



   


    //******* para el datapicker de fecha especifica *********//
    $scope.openedFEspecifica = false;
    $scope.openFEspecifica = function ($event) {
        $event.preventDefault();
        $event.stopPropagation();
        $scope.openedFEspecifica = true;
    };
    //*******Fin datapicker **************************//



    // si se selecciona el tipo de adhesion recurrente se impide que se pueda cargar un monto fijo en el pago
    $scope.FiltrarTipoMonto = function(item){
        if ($scope.pagoautomatico.tipoAdhesion.codigo == 'R' && item.codigo == 'F')
            return false;
        else
            return true;
    };



    $scope.SetearTipoFechaDesdeModal = function (mensaje) {
        var modal = $modal.open({
            templateUrl: "Default/ModalConfirm",
            controller: function () {

                $scope.title = "Alerta";
                $scope.description = mensaje;
                $scope.textbutton1 = "Ok";
                $scope.textbutton2 = "Indicar fecha específica";

                $scope.ok = function () {  //alert("funcion ok");
                    modal.close();
                }
                $scope.cancel = function () {    //alert("funcion cancel");
                    modal.close();
                    $scope.pagoautomatico.tipoFechaDebito = "F";
                }
            },
            windowClass: 'modal',
            animation: true,
            size: 'lg',
            backdrop: "static",
            keyboard: false,
            scope: $scope

        });


    };


    $scope.P2_CambioEnMismoTitular = function () {
        var cuitTitular = "20285856370";  // cliente.cliente.CuitTitular
        if ($scope.pagoautomatico.mismoTitular == "Si")
        {
            $scope.pagoautomatico.cuil = cuitTitular;
        }
        else
        {
            $scope.pagoautomatico.cuil = "";
        }
    };

    
    $scope.P2_SeleccionDeCuenta = function () {

        if ($scope.pagoautomatico.cuentasBancariasCliente != "Nueva")
        {
            $scope.pagoautomatico.cuentaExistenteSelected = true;
        }
        else
        {
            $scope.pagoautomatico.cuentaExistenteSelected = false;
        }
        
    };


    Init();

}]);