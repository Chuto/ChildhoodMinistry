app.directive("dirChildForm", function () {
    return {
        replace: false,
        restrict: "E",
        scope: {
            child: "=",
            childhoods: "=",
            formAction: "&"
        },
        templateUrl: "/scripts/crudApp/Directives/Templates/ChildForm.html"
    };
});