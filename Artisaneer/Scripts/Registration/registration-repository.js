'use strict';

registrationModule.factory('registrationRepository', function ($http, $q) {
    return {
        registerArtisan: function (art) {
            var deferred = $q.defer();
            $http.post('/Account/Register', art)
            .success(function () { deferred.resolve(); })
            .error(function () { deferred.reject();  });             
            return deferred.promise;
        },
        getStates: function () {
            return $http({ method: 'Get', url: '/Home/GetStates'});
        },
       
        //getLGA: function () {
        //    debugger;
        //    return $http({ method: 'POST', url: '/Home/GetLGA', data: JSON.stringify({ lgovtId: lgovtId }) });
        //},
        getSkills: function () {
            return $http({ method: 'Get', url: '/Home/GetSkills' });
        }      
    }
});

//getStates: function () {
//    return $resource('/Home/GetStates').query();
//},

//getLGA: function (lgovtId) {
//    return $resource('/Home/GetLGA/:lgovtId', { lgovtId: '@@lgovtId' }).query();
//},
////getAll: function () {
////    return $resource('/Home/GetAll').query();
////},
//save: function (artisan) {
//    $resource('/Account/Register').save(artisan);
//}