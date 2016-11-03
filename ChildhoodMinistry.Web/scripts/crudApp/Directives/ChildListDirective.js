app.directive("dirChildList", function () {
    return {
        replace: false,
        restrict: "E",
        scope: {
            children: "=",
            onEdit: "&",
            onDelete: "&"
        },
        controller: function() {},
        controllerAs: "vmList",
        bindToController: true,
        templateUrl: "/scripts/crudApp/Directives/Templates/ChildList.html"
    };
});