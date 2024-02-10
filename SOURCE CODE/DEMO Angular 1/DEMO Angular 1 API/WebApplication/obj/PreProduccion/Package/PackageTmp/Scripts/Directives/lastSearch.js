app.directive('lastsearch', function ($parse) {
    return {
        scope: true,
        replace: true,
        transclude: true,
        link: function (scope, element, attrs) {
            var c = scope.cache.get(attrs.ngModel + "_" + attrs.lastsearch);

            var model = $parse(attrs.lastsearch);

            if (c != undefined) {
                model.assign(scope, c);
            } else {
                model.assign(scope, []);
            }

            element.bind("keydown keypress", function (event) {
                if (event.which === 13) {
                    scope.$apply(function () {
                        if (scope.inArray(scope.$eval(attrs.ngModel), scope[attrs.lastsearch]) === -1) {
                            scope[attrs.lastsearch].push(scope.$eval(attrs.ngModel));
                        }

                        scope.cache.put(attrs.ngModel + "_" + attrs.lastsearch, scope[attrs.lastsearch]);

                    });

                    event.preventDefault();
                }
            });
        }
    }



});