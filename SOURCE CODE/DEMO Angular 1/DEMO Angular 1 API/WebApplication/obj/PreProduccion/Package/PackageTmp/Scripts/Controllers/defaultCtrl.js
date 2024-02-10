app.controller('defaultCtrl', ["$scope", "$modalInstance", "modal", function ($scope, $modalInstance, modal) {

    $scope.modal = modal;

    $scope.ok = function () {
        $modalInstance.close();
    };
    $scope.cancelar = function () {
        $modalInstance.close();
    };

}]);