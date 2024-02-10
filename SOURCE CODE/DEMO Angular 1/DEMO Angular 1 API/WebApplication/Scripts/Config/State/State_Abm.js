app.config(["$routeProvider", "$httpProvider", "$stateProvider"
      , function ($routeProvider, $httpProvider, $stateProvider) {
    $stateProvider
        .state("amb", {
            url: "",
            abstract: true,
            template: '<data-ui-view/>'
        })
        .state("amb.abmtablas", {
            url: "/abmtablas",
            controller: 'abmTablasCtrl',
            templateUrl: 'PagoAutomatico/AmbTablas/Index'
        })
         .state("amb.abmDelete", {
                      url: "/abmtablasDelete",
                      controller: 'abmTablasCtrl',
                      templateUrl: 'PagoAutomatico/AmbTablas/ModalDelete'
                  });
}]);