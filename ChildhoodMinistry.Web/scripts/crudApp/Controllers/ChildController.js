app.controller("ChildCrudController", function (crudChildService) {
    var vm = this;
    vm.paginationLoad = false;

    vm.loadPage = function (page) {
        if (page < 1 || page > vm.totalPages) {
            return;
        }
        vm.paginationLoad = false;
        vm.closeForm();
        var pageSize = 2;
        var getData = crudChildService.getPageOfChildren(page || 1, pageSize);
        getData.then(function (respon) {
            vm.children = respon.data.Data;
            vm.currentPage = respon.data.Page.CurrentPage;
            vm.totalPages = respon.data.Page.TotalPages;
            vm.paginationLoad = true;
        }, function () {
            alert('Ошибка чтения записи');
        });
    };

    function getChildhoods() {
        var getData = crudChildService.getChildhoods();
        getData.then(function (childhoods) {
            vm.childhoods = childhoods.data;
        }, function () {
            alert('Ошибка чтения записи');
        });
    }

    this.editChild = function (child) {
        vm.formAction = this.updateChild;
        vm.child = angular.copy(child);
        vm.showForm = true;
        getChildhoods();
    };

    vm.addChild = function () {
        var getData = crudChildService.addChild(vm.child);
        getData.then(function (msg) {
            vm.loadPage(1);
            alert(msg.data);
            vm.closeForm();
        }, function () {
            alert('Ошибка обновления записи');
        });
    };

    vm.updateChild = function () {
        var getData = crudChildService.updateChild(vm.child);
        getData.then(function (msg) {
            vm.loadPage(1);
            alert(msg.data);
            vm.closeForm();
        }, function () {
            alert('Ошибка добавления записи');
        });
    };

    vm.newChild = function () {
        vm.formAction = vm.addChild;
        vm.child = {};
        vm.showForm = true;
        getChildhoods();
    };

    vm.deleteChild = function (child) {
        var getData = crudChildService.deleteChild(child.Id);
        getData.then(function (msg) {
            alert(msg.data);
            vm.closeForm();
            vm.loadPage(1);
        }, function () {
            alert('Ошибка удаления записи');
        });
    };

    vm.closeForm = function () {
        vm.showForm = false;
    };

    vm.loadPage(1);
});

