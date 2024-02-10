app.config(["$routeProvider", "$httpProvider", "$stateProvider"
      , function ($routeProvider, $httpProvider, $stateProvider) {
          $stateProvider
            .state("adhesion", {
                url: "/adhesion",
                abstract: true,
                template: '<data-ui-view/>'
            })
            .state("adhesion.stopDebitAlta", {
                url: '/stopDebitAlta',
                controller: 'adhesionStopDebitAltaCtrl',
                templateUrl: 'PagoAutomatico/Adhesion/StopDebit'
            })
            .state("adhesion.stopDebitBaja", {
              url: '/stopDebitBaja',
              controller: 'adhesionStopDebitBajaCtrl',
              templateUrl: 'PagoAutomatico/Adhesion/StopDebit'
            })
          ;
      }]);