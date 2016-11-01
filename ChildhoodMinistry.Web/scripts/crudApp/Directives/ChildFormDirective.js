app.directive("dirChildForm", function () {
    return {
        replace: false,
        restrict: "A",
        scope: {
            child: "=child",
            Cancel: "=cancel",
            nums: "=nums",
            Submit: "=submit"
        },
        templateUrl: "/scripts/crudApp/Directives/Templates/ChildForm.html"
    };
});