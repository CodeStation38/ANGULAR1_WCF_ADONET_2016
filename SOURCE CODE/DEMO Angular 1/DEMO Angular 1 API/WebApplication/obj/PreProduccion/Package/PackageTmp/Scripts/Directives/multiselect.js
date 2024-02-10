﻿app.directive('multiSelect', function ($q) {
    return {
        restrict: 'E',
        require: 'ngModel',
        scope: {
            selectedLabel: "@",
            availableLabel: "@",
            displayAttr: "@",
            available: "=",
            model: "=ngModel"
        },
        template:   '<div class="row">' +
                    '    <div class="col-md-5 col-lg-5">' +
                    '        <label class="control-label" for="multiSelectSelected">' +
                    '            {{ selectedLabel }}' +
                    '            ({{ model.length }})' +
                    '        </label>' +
                    '    </div>' +
                    '    <div class="col-md-offset-2 col-lg-offset-2 col-md-5 col-lg-5">' +
                    '        <label class="control-label" for="multiSelectAvailable">' +
                    '            {{ availableLabel }}' +
                    '            ({{ available.length }})' +
                    '        </label>' +
                    '    </div>' +
                    '</div>' +
                    '<div class="row">' +
                    '    <div class="col-md-5 col-lg-5">' +
                    '        <div class="row">' +
                    '            <select id="currentRoles" ng-model="selected.current" multiple' +
                    '                    class="pull-left form-control" ng-options="e as e[displayAttr] for e in model"></select>' +
                    '        </div>' +
                    '    </div>' +
                    '    <div class="col-md-2 col-lg-2" style="text-align:center">' +
                    '        <div class="row">' +
                    '            <button class="btn btn-default" ng-click="add()" title="Add selected" ng-disabled="selected.available.length == 0">' +
                    '                <i class="glyphicon glyphicon-circle-arrow-left"></i>' +
                    '            </button>' +
                    '        </div>' +
                    '        <div class="row">' +
                    '            <button class="btn btn-default" ng-click="remove()" title="Remove selected" ng-disabled="selected.current.length == 0">' +
                    '                <i class="glyphicon glyphicon-circle-arrow-right"></i>' +
                    '            </button>' +
                    '        </div>' +
                    '    </div>' +
                    '    <div class="col-md-5 col-lg-5">' +
                    '        <div class="row">' +
                    '            <select id="multiSelectAvailable" class="form-control" ng-model="selected.available" multiple ng-options="e as e[displayAttr] for e in available"></select>' +
                    '        </div>' +
                    '    </div>' +
                    '</div>',
        link: function (scope, elm, attrs) {
            scope.selected = {
                available: [],
                current: []
            };

            /* Handles cases where scope data hasn't been initialized yet */
            var dataLoading = function (scopeAttr) {
                var loading = $q.defer();
                if (scope[scopeAttr]) {
                    loading.resolve(scope[scopeAttr]);
                } else {
                    scope.$watch(scopeAttr, function (newValue, oldValue) {
                        if (newValue !== undefined)
                            loading.resolve(newValue);
                    });
                }
                return loading.promise;
            };

            /* Filters out items in original that are also in toFilter. Compares by reference. */
            var filterOut = function (original, toFilter) {
                var filtered = [];
                angular.forEach(original, function (entity) {
                    var match = false;
                    for (var i = 0; i < toFilter.length; i++) {
                        if (toFilter[i][attrs.displayAttr] == entity[attrs.displayAttr]) {
                            match = true;
                            break;
                        }
                    }
                    if (!match) {
                        filtered.push(entity);
                    }
                });
                return filtered;
            };

            scope.refreshAvailable = function () {
                scope.available = filterOut(scope.available, scope.model);
                scope.selected.available = [];
                scope.selected.current = [];
            };

            scope.add = function () {
                scope.model = scope.model.concat(scope.selected.available);
                scope.refreshAvailable();
            };
            scope.remove = function () {
                scope.available = scope.available.concat(scope.selected.current);
                scope.model = filterOut(scope.model, scope.selected.current);
                scope.refreshAvailable();
            };

            $q.all([dataLoading("model"), dataLoading("available")]).then(function (results) {
                scope.refreshAvailable();
            });
        }
    };
})