app.controller("ChildhoodCRUDCtrl", function ($scope, crudChildhoodService, crudFactory) {
    $scope.crudFactory = crudFactory;
    $scope.divEdit = false;
    GetAllChildhoods();

    function GetAllChildhoods() {
        var getData = crudChildhoodService.getChildhoods();
        getData.then(function (childhood) {
            $scope.childhoods = childhood.data;
        }, function () {
            alert('Ошибка чтения записи');
        });
    }

    $scope.GetChildrenList = function (childhoodId) {
        var getData = crudChildhoodService.getChildrenList(childhoodId);
        getData.then(function (_childrenList) {
            //$scope.children = _childrenList.data;
            $scope.crudFactory.children = _childrenList.data;
            $scope.childhoodNum = childhoodId;
            $scope.divList = true;
            $scope.divEdit = false;
        }, function () {
            alert('Ошибка чтения записи');
        });
    }

    $scope.EditChildhood = function (childhood) {
        $scope.edit = true;
        $scope.save = false;
        var getData = crudChildhoodService.getChildhood(childhood.Ind);
        getData.then(function (_childhood) {
            $scope.childhood = _childhood.data;
            $scope.Action = "Редактирование";
            $scope.divEdit = true;
            $scope.divList = false;
        }, function () {
            alert('Ошибка чтения записи');
        });
    }

    $scope.AddChildhood = function () {
        var Childhood = $scope.childhood
        var getData = crudChildhoodService.AddChildhood(Childhood);
        getData.then(function (msg) {
            GetAllChildhoods();
            alert(msg.data);
            $scope.divEdit = false;
        }, function () {
            alert('Ошибка добавления записи');
        });
        $scope.save = false
    }

    $scope.UpdateChildhood = function () {
        var Childhood = $scope.childhood
        var getData = crudChildhoodService.updateChildhood(Childhood);
        getData.then(function (msg) {
            GetAllChildhoods();
            alert(msg.data);
            $scope.divEdit = false;
        }, function () {
            alert('Ошибка обновления записи');
        });
        $scope.edit = false;
    }

    $scope.AddChildhoodDiv = function () {
        $scope.childhood = null;
        $scope.Action = "Добавление";
        $scope.save = true;
        $scope.edit = false;
        $scope.divEdit = true;
        $scope.divList = false;
    }

    $scope.DeleteChildhood = function (childhood) {
        var getData = crudChildhoodService.DeleteChildhood(childhood.Ind);
        getData.then(function (msg) {
            alert(msg.data);
            $scope.divEdit = false;
            $scope.divList = false;
            GetAllChildhoods();
        }, function () {
            alert('Ошибка удаления записи');
        });
    }

    $scope.CancelChildrenList = function () {
        $scope.divEdit = false;
        $scope.divList = false;
    };
});