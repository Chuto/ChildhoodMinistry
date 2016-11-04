app.directive("dirChildhoodList", function () {
    return {
        replace: false,
        restrict: "E",
        scope: {
            childhoods: "=",
            onEdit: "&",
            onDelete: "&",
            getChildrenList: "&"
        },
        controller: function () { },
        controllerAs: "vmList",
        bindToController: true,
        templateUrl: "/scripts/crudApp/Directives/Templates/ChildhoodList.html"
    };
});