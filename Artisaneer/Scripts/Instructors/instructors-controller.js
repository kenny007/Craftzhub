'use strict';

registrationModule.controller("InstructorsController", function ($scope, instructorRepository) {
    //note that the scope we have up here will be accessible to the html housing the data
    $scope.instructors = instructorRepository.get();
});