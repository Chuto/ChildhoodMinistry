app.directive("dirListItems", function () {
    return {
        replace: false,
        restrict: 'A',
        scope: {
            children: '=children',
            childhoodNum: '@childhoodnum',
            GetChildrenList : '=f'
        },
        templateUrl: '/scripts/crudApp/Directives/Templates/Children.html'
    };
});