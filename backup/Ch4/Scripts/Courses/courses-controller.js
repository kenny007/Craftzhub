//Note that ur controller should just be an entry point to and from your views here the courseRepository is  a service
registrationModule.controller("CoursesController", function ($scope, courseRepository) {
    //note that the scope we have up here will be accessible to the html housing the data
    //This is telling us when the promise finishes whether is succeeds or fails "then do this"
    courseRepository.get().then(function (courses) { $scope.courses = courses; });
    //when it succeeds populate the courses that is wt the fxn does
  
});