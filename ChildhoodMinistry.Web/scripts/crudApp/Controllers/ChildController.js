app.controller("ChildCRUDCtrl", function ($scope, crudService) {

    $scope.pager = {};
    $scope.setPage = function (page) {
        if (page < 1 || page > $scope.pager.totalPages) {
            return;
        }
        currentPage = page || 1;
        pageSize = 2;
        $scope.edit = false;
        $scope.save = false;
        var getData = crudService.sendRequest("post", "/Child/GetPage", { page: currentPage, pageSize: pageSize });
        getData.then(function (respon) {
            $scope.children = respon.data.data;
            currentPage = respon.data.currentPage;
            pageSize = respon.data.pageSize;
            totalItems = respon.data.totalItems;
            totalPages = respon.data.totalPages;

            var startPage, endPage;

            if (totalPages <= 10) {
                startPage = 1;
                endPage = totalPages;
            } else {
                if (currentPage <= 6) {
                    startPage = 1;
                    endPage = 10;
                } else if (currentPage + 4 >= totalPages) {
                    startPage = totalPages - 9;
                    endPage = totalPages;
                } else {
                    startPage = currentPage - 5;
                    endPage = currentPage + 4;
                }
            }

            var startIndex = (currentPage - 1) * pageSize;
            var endIndex = Math.min(startIndex + pageSize - 1, totalItems - 1);
            var pages = _.range(startPage, endPage + 1);

            $scope.pager = {
                totalItems: totalItems,
                currentPage: currentPage,
                pageSize: pageSize,
                totalPages: totalPages,
                startPage: startPage,
                endPage: endPage,
                startIndex: startIndex,
                endIndex: endIndex,
                pages: pages
            };
        }, function () {
            alert('Ошибка чтения записи');
        });
    };

    if ($scope.childhoodNum === undefined)
        $scope.setPage(1);

    $scope.EditChild = function (child) {
        GetChildhoodNum();
        $scope.edit = true;
        $scope.save = false;
        var getData = crudService.sendRequest("post","/Child/GetChildById", {id:child.Ind});
        getData.then(function (_child) {
            $scope.child = _child.data;
            $scope.Action = "Редактирование";
            $scope.divEdit = true;
        }, function () {
            alert('Ошибка чтения записи');
        });
    };

    $scope.AddChild = function () {
        var Child = $scope.child;
        Child.Id = $scope.child.Ind;
        var getData = crudService.sendRequest("post", "/Child/AddChild", { child: Child });
        getData.then(function (msg) {
            if ($scope.childhoodNum)
                $scope.GetChildrenList(parseInt($scope.childhoodNum));
            else
                $scope.setPage(1);
            alert(msg.data);
            $scope.divEdit = false;
        }, function () {
            alert('Ошибка обновления записи');
        });
        $scope.save = false;
    };

    $scope.UpdateChild = function () {
        var Child = $scope.child;
        var getData = crudService.sendRequest("post", "/Child/UpdateChild", { child: Child });
        getData.then(function (msg) {
            if ($scope.childhoodNum)
                $scope.GetChildrenList(parseInt($scope.childhoodNum));
            else
                $scope.setPage(1);
            alert(msg.data);
            $scope.divEdit = false;
        }, function () {
            alert('Ошибка добавления записи');
        });
        $scope.edit = false;
    };

    $scope.AddChildDiv = function () {
        $scope.child = null;
        GetChildhoodNum();
        $scope.edit = false;
        $scope.save = true;
        $scope.Action = "Добавление";
        $scope.divEdit = true;
    };

    $scope.DeleteChild = function (child) {
        var getData = crudService.sendRequest("post", "/Child/DeleteChild", { id: child.Ind });
        getData.then(function (msg) {
            alert(msg.data);
            $scope.divEdit = false;
            if ($scope.childhoodNum)
                $scope.GetChildrenList(parseInt($scope.childhoodNum));
            else
                $scope.setPage(1);
        }, function () {
            alert('Ошибка удаления записи');
        });
    };

    function GetChildhoodNum() {
        var getData = crudService.sendRequest("get", "/Childhood/GetChildhoodNum");
        getData.then(function (_num) {
            $scope.nums = _num.data;
        }, function () {
            alert('Ошибка чтения записи');
        });
    }

    $scope.Cancel = function () {
        $scope.divEdit = false;
    };
});

