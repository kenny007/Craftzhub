
registrationModule.controller('ArtisanController', function ($scope, $location, artisanRepository) {
      
    $scope.skills = artisanRepository.getSkills();
            
    $scope.search = function () {
        artisanRepository.getAll().query({
            q:  $scope.query,
            sort: $scope.sort_order,
            offset: $scope.offset,
            limit:$scope.limit
        },

        function (data) {
            $scope.more = data.length === 10;
            $scope.items = $scope.items.concat(data);
        });
    };
    
    $scope.sort = function (col) {
        $scope.sort_order = col;
        $scope.reset();
    };

    $scope.show_more = function () {
        $scope.offset += $scope.limit;
        $scope.search();
    };

    $scope.has_more = function () {
        return $scope.more;
    };

    $scope.reset = function () {
        //debugger;
        $scope.limit = 10;
        $scope.offset = 0;
        $scope.items = [];
        $scope.more = true;
        $scope.search();
    };

    $scope.sort_order = "LastName";
    //$scope.is_desc = false;  
    $scope.reset();
    
});

