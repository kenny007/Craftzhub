registrationModule.factory('courseRepository', function ($http, $q) {
    return {
        //the get method will be a fxn that calls the http service we're injecting the http and q service(for handling response)
        get: function () {
            var deferred = $q.defer();
            $http.get('/Courses').success(deferred.resolve).error(deferred.reject);
        //Note that promises enables us to handle asynchronous communication more easily and the q injected here is a promise library
            return deferred.promise;//And this basically is saying I promise to tell you in the future whether the action was successful or not
        }
    }
});