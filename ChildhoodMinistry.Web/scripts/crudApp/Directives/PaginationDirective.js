app.directive("dirPagination", function () {
    return {
        replace: false,
        restrict: "A",
        scope: {
            setPage: "=loadPage",
            pager: "=page"
        },
        templateUrl: "/scripts/crudApp/Directives/Templates/Pagination.html",
    };
});