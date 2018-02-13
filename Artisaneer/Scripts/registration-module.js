
var registrationModule = angular.module("registrationModule", ['ngRoute', 'ngResource'])
 .config(function ($routeProvider, $locationProvider) {
     // It means when the route is '/Registration/*' use this
     $routeProvider.when('/Home/Index', { templateUrl: '/', controller: 'HomeController' });
     $routeProvider.when('/Registration/Login', { templateUrl: '/templates/login.html', controller: 'LoginController' });
     $routeProvider.when('/Registration/Register', { templateUrl: '/templates/register.html', controller: 'RegistrationController' });
     $routeProvider.when('/Registration/CreateAccount', { templateUrl: '/templates/create-account.html', controller: 'AccountController' });
     $routeProvider.when('/Home/About', { templateUrl: '/', controller:'ArtisanController'});
     $routeProvider.when('/Artisan/Index', { templateUrl: '/appcore/index.html', controller: 'ArtisanController' });
     $routeProvider.when('/appcore/index.html', { templateUrl: '/appcore/index.html', controller: 'ArtisanController' });
     $routeProvider.when('/Artisan/Hire', { templateUrl: '/appcore/hire.html', controller:'ArtisanController' });
     $locationProvider.html5Mode(true); //so that we don't have hashing our url    
 });
//we can still use .otherwise to redirect to the previous page or a default page 

