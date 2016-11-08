app.directive("dirChildhoodForm", function () {
    return {
        replace: false,
        restrict: "E",
        scope: {
            childhood: "=",
            onSubmit: "&"
        },
        controller: function () { },
        controllerAs: "vmForm",
        bindToController: true,
        templateUrl: "/scripts/crudApp/Directives/Templates/ChildhoodForm.html"
    };
});