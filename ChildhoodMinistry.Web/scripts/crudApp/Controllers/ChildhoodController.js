app.controller("ChildhoodCrudController", ["crudChildhoodService", function (crudChildhoodService) {
    var vm = this;
    vm.paginationLoad = false;
    
    vm.loadPage = function (page) {
        if (page < 1 || page > vm.totalPages) {
            return;
        }
        vm.paginationLoad = false;
        vm.closeForm();
        var pageSize = 2;
        var getData = crudChildhoodService.getPageOfChildhoods(page || 1, pageSize);
        getData.then(function (respon) {
            vm.childhoods = respon.data.Data;
            vm.currentPage = respon.data.Page.CurrentPage;
            vm.totalPages = respon.data.Page.TotalPages;
            vm.paginationLoad = true;
        }, function () {
            alert("Ошибка чтения записи");
        });
    };

    vm.getChildrenList = function (childhood) {
        var getData = crudChildhoodService.getChildrenList(childhood.Id);
        getData.then(function (childrenList) {
            vm.children = childrenList.data;
            vm.childrenList = true;
            vm.showForm = false;
        }, function () {
            alert('Ошибка чтения записи');
        });
    };

    vm.editChildhood = function (childhood) {
        vm.formAction = vm.updateChildhood;
        vm.childhood = angular.copy(childhood);
        vm.showForm = true;
        vm.childrenList = false;
    };

    vm.addChildhood = function () {
        var getData = crudChildhoodService.addChildhood(vm.childhood);
        getData.then(function (msg) {            
            alert(msg.data);
            vm.loadPage(1);
            vm.closeForm();
        }, function () {
            alert("Ошибка добавления записи");
        });
    };

    vm.updateChildhood = function () {
        var getData = crudChildhoodService.updateChildhood(vm.childhood);
        getData.then(function (msg) {
            alert(msg.data);
            vm.loadPage(1);
            vm.closeForm();
        }, function () {
            alert("Ошибка обновления записи");
        });
    };

    vm.deleteChildhood = function (childhood) {
        var getData = crudChildhoodService.deleteChildhood(childhood.Id);
        getData.then(function (msg) {
            alert(msg.data);
            vm.closeForm();
            vm.loadPage(1);
        }, function () {
            alert("Ошибка удаления записи");
        });
    };

    vm.newChildhood = function () {
        vm.formAction = vm.addChildhood;
        vm.childhood = {};
        vm.showForm = true;
        vm.childrenList = false;
    };

    vm.closeForm = function () {
        vm.showForm = false;
        vm.childrenList = false;
    };

    vm.loadPage(1);
}]);
