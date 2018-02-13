registrationModule.directive('pwCheck', [function () {
    return {
        require: 'ngModel',
        link: function (scope, elem, attrs, ctrl) {
            var firstPassword = '#' + attrs.pwCheck;
            elem.add(firstPassword).on('keyup', function () {
                scope.$apply(function () {
                    var v = elem.val() === $(firstPassword).val();
                    ctrl.$setValidity('pwmatch', v);
                });
            });
        }
    }
}]);

registrationModule.directive('ngUnique', ['$http', function (async) {
    return {
        require: 'ngModel',
        link: function (scope, elem, attrs, ctrl) {

            elem.on('blur', function (evt) {
                scope.$apply(function () {
                    var val = elem.val();
                    var req = { "userName": val }
                    var ajaxConfiguration = { method: 'POST', url: 'IsUserAvailable', data: req };
                    async(ajaxConfiguration)
                        .success(function (data, status, headers, config) {
                            ctrl.$setValidity('unique', data.result);
                        });
                });
            });
        }
    }
}]);