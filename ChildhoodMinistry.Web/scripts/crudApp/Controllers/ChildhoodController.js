app.controller("ChildhoodCRUDCtrl", function ($scope, crudService) {

    $scope.pager = {};

    $scope.setPage = function (page) {
        if (page < 1 || page > $scope.pager.totalPages) {
            page = 1;
        }
        $scope.divEdit = false;
        $scope.divList = false;
        var currentPage = page || 1;
        var pageSize = 2;

        var getData = crudService.sendRequest("post", "/Childhood/GetPage", { page: currentPage, pageSize: pageSize });
        getData.then(function (respon) {
            $scope.childhoods = respon.data.Data;
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
            alert("Ошибка чтения записи");
        });
    };

    $scope.setPage(1);

    $scope.GetChildrenList = function (childhoodId) {
        var getData = crudService.sendRequest("post", "/Child/GetChildByChildhoodId", { id: childhoodId });
        getData.then(function (childrenList) {
            $scope.children = childrenList.data;
            $scope.childhoodNum = childhoodId;

            $scope.divList = true;
            $scope.divEdit = false;

        }, function () {
            alert('Ошибка чтения записи');
        });
    };

    $scope.EditChildhood = function (id) {
        $scope.edit = true;
        $scope.save = false;
        var getData = crudService.sendRequest("post","/Childhood/GetChildhoodById", { id: id });
        getData.then(function (childhood) {
            $scope.childhood = childhood.data;
            $scope.Action = "Редактирование";
            $scope.divEdit = true;
            $scope.divList = false;
        }, function () {
            alert('Ошибка чтения записи');
        });
    };

    $scope.AddChildhood = function () {
        var childhood = $scope.childhood;
        var getData = crudService.sendRequest("post", "/Childhood/AddChildhood", { childhood: childhood });
        getData.then(function (msg) {            
            alert(msg.data);
            $scope.setPage(1);
            $scope.divEdit = false;
        }, function () {
            alert("Ошибка добавления записи");
        });
        $scope.save = false;
    };

    $scope.UpdateChildhood = function () {
        var childhood = $scope.childhood;
        var getData = crudService.sendRequest("post", "/Childhood/UpdateChildhood", { childhood: childhood });
        getData.then(function (msg) {
            alert(msg.data);
            $scope.setPage(1);
            $scope.divEdit = false;
        }, function () {
            alert("Ошибка обновления записи");
        });
        $scope.edit = false;
    };

    $scope.DeleteChildhood = function (id) {
        var getData = crudService.sendRequest("post", "/Childhood/DeleteChildhood", { id: id });
        getData.then(function (msg) {
            alert(msg.data);
            $scope.divEdit = false;
            $scope.divList = false;
            $scope.setPage(1);
        }, function () {
            alert("Ошибка удаления записи");
        });
    };

    $scope.AddChildhoodDiv = function () {
        $scope.childhood = null;
        $scope.Action = "Добавление";
        $scope.save = true;
        $scope.edit = false;
        $scope.divEdit = true;
        $scope.divList = false;
    };

    $scope.CancelChildrenList = function () {
        $scope.divEdit = false;
        $scope.divList = false;
    };
});
