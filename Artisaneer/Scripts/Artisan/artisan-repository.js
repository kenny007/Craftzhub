'use strict';

registrationModule.factory('artisanRepository', function ($resource,$http) {
    return {
        getAll: function () {
            //This means each time we are interacting with the api choose this path
            return $resource('/Artisan/GetArtisans/:id', { id: '@id' }, { update: {method:'PUT'}});
        },

        getSkills: function () {
            return $resource('/Home/GetSkills').query();
        }
    }
});