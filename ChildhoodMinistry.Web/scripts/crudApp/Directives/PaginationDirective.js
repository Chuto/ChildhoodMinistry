app.directive("dirPagination", function () {
    return {
        replace: false,
        restrict: "E",
        scope: {
            loadPage: "&",
            currentPage: "=",
            totalPages: "="
        },
        controller: "PagingController",
        controllerAs: "vmPage",
        bindToController: true,
        templateUrl: "/scripts/crudApp/Directives/Templates/Pagination.html"
    };
});