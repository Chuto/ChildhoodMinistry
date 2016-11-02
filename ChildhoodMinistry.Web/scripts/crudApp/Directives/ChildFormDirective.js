app.directive("dirChildForm", function () {
    return {
        replace: false,
        restrict: "E",
        scope: {
            child: "=",
            nums: "=",
            confirm: "&"
        },
        templateUrl: "/scripts/crudApp/Directives/Templates/ChildForm.html"
    };
});