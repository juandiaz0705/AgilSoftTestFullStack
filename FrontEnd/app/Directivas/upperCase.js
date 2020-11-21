myApp.directive('uppercaseMe', function () {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function (scope, element, attr, ngModel) {
            var fromUser = function (text) {
                if (angular.isDefined(text)) {
                    return text.toUpperCase();
                }
            };

            ngModel.$parsers.push(fromUser);
        }
    };
});