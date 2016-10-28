app.controller("ChildCRUDCtrl", function ($scope, crudService) {

    $scope.pager = {};
    $scope.setPage = function (page) {
        if (page < 1 || page > $scope.pager.totalPages) {
            page = 1;
        }
        var currentPage = page || 1;
        var pageSize = 2;
        $scope.edit = false;
        $scope.save = false;
        $scope.divEdit = false;
        var getData = crudService.sendRequest("post", "/Child/GetPage", { page: currentPage, pageSize: pageSize });
        getData.then(function (respon) {
            $scope.children = respon.data.Data;
            currentPage = respon.data.Page.CurrentPage;
            pageSize = respon.data.Page.PageSize;
            var totalItems = respon.data.Page.TotalItems;
            var totalPages = respon.data.Page.TotalPages;

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
            var pages = window._.range(startPage, endPage + 1);

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

    function getChildhoodNum() {
        var getData = crudService.sendRequest("get", "/Childhood/GetNumberOfChildhoods");
        getData.then(function (num) {
            $scope.nums = num.data;
        }, function () {
            alert('Ошибка чтения записи');
        });
    }

    $scope.EditChild = function (child) {
        getChildhoodNum();
        $scope.edit = true;
        $scope.save = false;
        var getData = crudService.sendRequest("post","/Child/GetChildById", {id:child.Ind});
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
        child.Id = $scope.child.Ind;
        var getData = crudService.sendRequest("post", "/Child/AddChild", { child: child });
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
        var child = $scope.child;
        var getData = crudService.sendRequest("post", "/Child/UpdateChild", { child: child });
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
        getChildhoodNum();
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
    $scope.Cancel = function () {
        $scope.divEdit = false;
    };
});

