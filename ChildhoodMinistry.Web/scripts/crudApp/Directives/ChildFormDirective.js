app.directive("dirChildForm", function () {
    return {
        replace: false,
        restrict: "A",
        scope: {
            child: "=",
            nums: "=",
            confirm: "&"
        },
        templateUrl: "/scripts/crudApp/Directives/Templates/ChildForm.html"
    };
});