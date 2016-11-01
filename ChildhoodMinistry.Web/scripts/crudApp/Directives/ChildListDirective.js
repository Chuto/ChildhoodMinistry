app.directive("dirChildList", function () {
    return {
        replace: false,
        restrict: "A",
        scope: {
            children: "=children",
            Edit: "=editFunc",
            Delete: "=deleteFunc"
        },
        templateUrl: "/scripts/crudApp/Directives/Templates/ChildList.html"
    };
});