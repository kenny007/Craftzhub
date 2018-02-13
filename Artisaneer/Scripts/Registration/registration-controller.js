registrationModule.controller('RegistrationController', function ($scope, registrationRepository, $window,$http) {
    $scope.status;
    $scope.artisan;

  
 
    $scope.save = function () {
        var art = $scope.artisan;
        $scope.error = [];
        registrationRepository.registerArtisan(art)
          .then(
            function () {
                $scope.status = "You are welcome to the league of great men!";
                $window.location.href = '/Artisan/Index';
               // $location.url('/Registration/Login');
            },
            function (response) {
                $scope.status = "Oops something went wrong, we were unable to complete the request. Please try again later.";
               // $scope.error = true;
            });
    } 

    function getSkills() {
        registrationRepository.getSkills()
        .success(function (data, status, headers, config) {
            $scope.skills = data;
        }).error(function (data, status, headers, config) {
            $scope.skills = "Unexpected error";
        });
    };

    function getStates() {
        registrationRepository.getStates()
       .success(function (data, status, headers, config) {
            $scope.states = data;
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });
    }

    $scope.getLGA = function () {
        
        var stateId = $scope.artisan.state;
        if (stateId) {
            $http({
                method: 'POST',
                url: '/Home/GetLGA/',
                data: JSON.stringify({ stateId: stateId })
            }).success(function (data, status, headers, config) {
                $scope.lgovts = data;
            }).error(function (data, status, headers, config) {
                $scope.message = 'Unexpected Error';
            });
        }
        else {
            $scope.lgovts = null;
        }
    }

    getStates();
    getSkills();


        //  .$promise.then(
        //function () { $location.url('Home/Index'); },
        //function (response) { $scope.errors = response.data; })
});

    //$scope.getLGA = function () {
    //    var lgovtId = $scope.state;
    //    if (lgovtId) {
    //        registrationRepository.getLGA()
    //            .success(function (data, status, headers, config) {
    //                $scope.lgovts = data;
    //        }).error(function (data, status, headers, config) {
    //            $scope.message = 'Unexpected Error';
    //        });
    //    }
    //    else {
    //       // $scope.states = null;
    //    }
    //}

//// $scope.allItems = registrationRepository.getAll();

//$scope.save = function (artisan) {
//    $scope.errors = [];
//    registrationRepository.save(artisan).$promise.then(
//        function () { $location.url('Home/Index'); },
//        function (response) { $scope.errors = response.data; })
//};

//$scope.states = registrationRepository.getStates();

//$scope.getLGA = function () {
//    var lgovtId = $scope.state;
//    if (lgovtId) {
//        $scope.lgovts = registrationRepository.getLGA(lgovtId);
//    }
//    else {
//        $scope.lgovts = null;
//    }
//}