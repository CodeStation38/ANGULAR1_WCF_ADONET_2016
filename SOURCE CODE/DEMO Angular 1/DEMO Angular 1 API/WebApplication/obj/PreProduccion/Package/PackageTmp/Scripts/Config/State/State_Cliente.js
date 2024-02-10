app.config(["$httpProvider", "$stateProvider"
    , function ( $httpProvider, $stateProvider) {
        $stateProvider
            .state("cliente", {
                url: "",
                abstract: true,
                template: '<data-ui-view/>'
            })
            .state("cliente.home", {
                url: "/home",
                templateUrl: 'PagoAutomatico/Cliente/clienteBusqueda',
                onEnter: ["cliente", "adhesion", function (cliente, adhesion) {
                    adhesion.limpiarAdhesion();
                    cliente.limpiarCliente();
                }]
            })
            .state("cliente.adhesionesVigentes", {
                url: "/adhesionesVigentes/:clienteId",
                templateUrl: 'PagoAutomatico/Cliente/clienteHome'
            })
            .state("cliente.debitos", {
                url: '/debitos/:adhesionId/:origen',
                templateUrl: 'PagoAutomatico/Cliente/clienteConsultaDebitos'
            })
            .state("cliente.historicoAdhesiones", {
                url: '/historicoAdhesiones/:clienteId',
                templateUrl: 'PagoAutomatico/Cliente/clienteHistoricoAdhesiones'
            })
            .state("cliente.historicoCambios", {
                url: '/historicoCambios',
                controller: 'historicoCambiosCtrl',
                templateUrl: 'PagoAutomatico/HistoricoCambios/historicoCambios'
            })
            .state("cliente.altaPagoAutomatico", {
                url: '/altaPagoAutomatico',
                templateUrl: 'PagoAutomatico/Cliente/clienteAltaPagoAutomatico',
                controller: 'clienteAltaPagoAutomaticoCtrl',
                abstract: true,
            })
            .state("cliente.altaPagoAutomatico.Paso1", {
                templateUrl: 'PagoAutomatico/Cliente/clienteAltaPagoAutomaticoPaso1'
            })
            .state("cliente.altaPagoAutomatico.Paso2", {
                templateUrl: 'PagoAutomatico/Cliente/clienteAltaPagoAutomaticoPaso2'
            })
            .state("cliente.altaPagoAutomatico.Paso3", {
                templateUrl: 'PagoAutomatico/Cliente/clienteAltaPagoAutomaticoPaso3'
            }); 
            
    }]);
