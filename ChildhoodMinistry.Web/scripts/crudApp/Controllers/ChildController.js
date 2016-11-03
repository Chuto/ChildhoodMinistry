app.controller("ChildCrudController", function ($scope, crudChildService) {
    $scope.paginationLoad = false;

    $scope.loadPage = function (page) {
        if (page < 1 || page > $scope.totalPages) {
            return;
        }
        $scope.paginationLoad = false;
        $scope.closeForm();
        var pageSize = 2;
        var getData = crudChildService.getPageOfChildren(page || 1, pageSize);
        getData.then(function (respon) {
            $scope.children = respon.data.Data;
            $scope.currentPage = respon.data.Page.CurrentPage;
            $scope.totalPages = respon.data.Page.TotalPages;
            $scope.paginationLoad = true;
        }, function () {
            alert('Ошибка чтения записи');
        });
    };

    function getChildhoods() {
        var getData = crudChildService.getChildhoods();
        getData.then(function (childhoods) {
            $scope.childhoods = childhoods.data;
        }, function () {
            alert('Ошибка чтения записи');
        });
    }

    $scope.editChild = function (child) {
        $scope.formAction = $scope.updateChild;
        $scope.child = angular.copy(child);
        $scope.showForm = true;
        getChildhoods();
    };

    $scope.addChild = function () {
        var getData = crudChildService.addChild($scope.child);
        getData.then(function (msg) {
            $scope.loadPage(1);
            alert(msg.data);
            $scope.closeForm();
        }, function () {
            alert('Ошибка обновления записи');
        });
    };

    $scope.updateChild = function () {
        var getData = crudChildService.updateChild($scope.child);
        getData.then(function (msg) {
            $scope.loadPage(1);
            alert(msg.data);
            $scope.closeForm();
        }, function () {
            alert('Ошибка добавления записи');
        });
    };

    $scope.newChild = function () {
        $scope.formAction = $scope.addChild;
        $scope.child = {};
        $scope.showForm = true;
        getChildhoods();
    };

    $scope.deleteChild = function (child) {
        var getData = crudChildService.deleteChild(child.Id);
        getData.then(function (msg) {
            alert(msg.data);
            $scope.closeForm();
            $scope.loadPage(1);
        }, function () {
            alert('Ошибка удаления записи');
        });
    };

    $scope.closeForm = function () {
        $scope.showForm = false;
    };

    $scope.loadPage(1);
});

