'use strict';
//Note that ur controller should just be an entry point to and from your views here the courseRepository is  a service
registrationModule.controller("LoginController", function ($scope, loginRepository, $window) {

    $scope.login = function () {
        var acc = $scope.access;
        $scope.error = [];
        loginRepository.getAccess(acc)
          .then(
            function () {
                //$scope.status = "You are welcome to the league of great men!";
                $window.location.href = '/Artisan/Index';
            },
            function (response) {
                $scope.status = "Oops something went wrong, we were unable to authenticate user. Please try again later.";
                // $scope.error = true;
            });
        //when it succeeds populate the courses that is wt the fxn does

    }
});