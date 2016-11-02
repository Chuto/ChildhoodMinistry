app.controller("ChildCRUDCtrl", function ($window, $scope, crudChildService) {
    $scope.ready = false;
    $scope.Submit;

    $scope.setPage = function (page) {
        if (page < 1 || page > $scope.totalPages) {
            return;
        }
        var pageSize = 2;
        $scope.divEdit = false;
        var getData = crudChildService.GetPageOfChild(page || 1, pageSize);
        getData.then(function (respon) {
            $scope.children = respon.data.Data;
            $scope.currentPage = respon.data.Page.CurrentPage;
            $scope.totalPages = respon.data.Page.TotalPages;
            $scope.ready = true;
        }, function () {
            alert('Ошибка чтения записи');
        });
    };

    $scope.setPage(1);

    function getChildhoodNum() {
        var getData = crudChildService.GetChildhoods();
        getData.then(function (num) {
            $scope.nums = num.data;
        }, function () {
            alert('Ошибка чтения записи');
        });
    }

    $scope.EditChild = function (child) {
        $scope.Submit = $scope.UpdateChild;
        getChildhoodNum();
        var getData = crudChildService.GetChildById(child.Ind);
        getData.then(function (item) {
            $scope.child = item.data;
            $scope.Action = "Редактирование";
            $scope.divEdit = true;
        }, function () {
            alert('Ошибка чтения записи');
        });
    };

    $scope.AddChild = function () {
        var child = $scope.child;
        $scope.child.ChildhoodId = $.grep($scope.nums, function (e) { return e.Number == $scope.child.ChildhoodNum })[0].Ind;
        var getData = crudChildService.AddChild($scope.child);
        getData.then(function (msg) {
            $window.location.href = '/Child';
            alert(msg.data);
            $scope.divEdit = false;
        }, function () {
            alert('Ошибка обновления записи');
        });
    };

    $scope.UpdateChild = function () {
        $scope.child.ChildhoodId = $.grep($scope.nums, function (e) { return e.Number == $scope.child.ChildhoodNum })[0].Ind;
        var getData = crudChildService.UpdateChild($scope.child);
        getData.then(function (msg) {
            $window.location.href = '/Child';
            alert(msg.data);
            $scope.divEdit = false;
        }, function () {
            alert('Ошибка добавления записи');
        });
    };

    $scope.AddChildDiv = function () {
        $scope.Submit = $scope.AddChild;
        $scope.child = {};
        getChildhoodNum();
        $scope.Action = "Добавление";
        $scope.divEdit = true;
    };

    $scope.DeleteChild = function (Ind) {
        var getData = crudChildService.DeleteChild(Ind);
        getData.then(function (msg) {
            alert(msg.data);
            $scope.divEdit = false;
            $window.location.href = '/Child';
        }, function () {
            alert('Ошибка удаления записи');
        });
    };
    $scope.Cancel = function () {
        $scope.divEdit = false;
    };
});

