
var registrationModule = angular.module("registrationModule",[])
 .config(function ($routeProvider, $locationProvider) {
     $routeProvider.when('/Registration/Courses', { templateUrl: '/templates/courses.html', controller: 'CoursesController' });
     $routeProvider.when('/Registration/Instructors', { templateUrl: '/templates/instructors.html', controller: 'InstructorsController' });
     $routeProvider.when('/Registration/CreateAccount', { templateUrl: '/templates/create-account.html', controller: 'AccountController' });
     console.log(registrationModule);
     $locationProvider.html5Mode(true); //so that we don't have hashin our url
 });