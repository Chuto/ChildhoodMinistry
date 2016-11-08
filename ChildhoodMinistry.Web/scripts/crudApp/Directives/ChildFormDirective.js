app.directive("dirChildForm", function () {
    return {
        replace: false,
        restrict: "E",
        scope: {
            child: "=",
            childhoods: "=",
            onAction: "&"
        },
        controller: function () { },
        controllerAs: "vmForm",
        bindToController: true,
        templateUrl: "/scripts/crudApp/Directives/Templates/ChildForm.html"
    };
});