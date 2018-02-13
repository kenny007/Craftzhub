registrationModule.factory('instructorRepository', function ($resource) {
    return {
        //the get method will be a fxn that calls the http service we're injecting the http and q service(for handling response)
        get: function () {
          return  $resource('/api/Instructors').query();
            //Note that promises enables us to handle asynchronous communication more easily
        }
    }
});