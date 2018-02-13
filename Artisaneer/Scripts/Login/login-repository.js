'use strict';

registrationModule.factory('loginRepository', function ($http,$q) {
    return {
        //the get method will be a fxn that calls the http service we're injecting the http and q service(for handling response)
        getAccess: function (acc) {
           var deferred = $q.defer();
           $http.post('/Account/Login', acc)
           .success(function () { deferred.resolve(); })
           .error(function () { deferred.reject();  });             
            return deferred.promise;
        //Note that promises enables us to handle asynchronous communication more easily and the q injected here is a promise library
        //And this basically is saying I promise to tell you in the future whether the action was successful or not
        }
    }
});
//var factory = {};
//factory.getCustomers = function () {
//    return customers;
//};