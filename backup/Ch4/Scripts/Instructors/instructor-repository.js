registrationModule.factory('instructorRepository', function ($http, $q) {
    return {
        //the get method will be a fxn that calls the http service we're injecting the http and q service(for handling response)
        get: function () {
            var deferred = $q.defer();
            $http.get('/Instructors').success(deferred.resolve).error(deferred.reject);
            //Note that promises enables us to handle asynchronous communication more easily
            return deferred.promise;
        }
    }
});