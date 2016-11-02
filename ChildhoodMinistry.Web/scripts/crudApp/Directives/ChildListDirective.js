app.directive("dirChildList", function () {
    return {
        replace: false,
        restrict: "E",
        scope: {
            children: "=",
            onEdit: "&",
            onDelete: "&"
        },
        templateUrl: "/scripts/crudApp/Directives/Templates/ChildList.html"
    };
});