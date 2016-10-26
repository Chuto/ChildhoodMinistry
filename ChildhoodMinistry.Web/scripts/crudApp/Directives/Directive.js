app.directive("dirListItems", function () {
    return {
        replace: false,
        restrict: "A",
        scope: {
            children: "=children",
            childhoodNum: "@childhoodNum",
            GetChildrenList : "=getChildrenList"
        },
        templateUrl: "/scripts/crudApp/Directives/Templates/Children.html"
    };
});