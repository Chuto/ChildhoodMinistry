app.directive("dirPagination", function () {
    return {
        replace: false,
        restrict: "E",
        scope: {
            setPage: "&",
            currentPage: "=",
            totalPages: "="
        },
        templateUrl: "/scripts/crudApp/Directives/Templates/Pagination.html",
        controller: function ($scope) {
                var startPage, endPage;

                if ($scope.totalPages <= 10) {
                    startPage = 1;
                    endPage = $scope.totalPages;
                } else {
                    if ($scope.currentPage <= 6) {
                        startPage = 1;
                        endPage = 10;
                    } else if ($scope.currentPage + 4 >= $scope.totalPages) {
                        startPage = $scope.totalPages - 9;
                        endPage = $scope.totalPages;
                    } else {
                        startPage = $scope.currentPage - 5;
                        endPage = $scope.currentPage + 4;
                    }
                }

                var startIndex = ($scope.currentPage - 1) * $scope.PageSize;
                var endIndex = Math.min(startIndex + $scope.PageSize - 1, $scope.TotalItems - 1);
                $scope.pages = window._.range(startPage, endPage + 1);

            $scope.LoadPage = function(num) {
                $scope.setPage({ page: num })
            };
        }
    };
});