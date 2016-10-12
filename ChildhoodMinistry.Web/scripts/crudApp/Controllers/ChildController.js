app.controller("ChildCRUDCtrl", function ($scope, crudChildService ) {

    if ($scope.childhoodNum === undefined)
        GetAllChildren();

    function GetAllChildren() {
        var getData = crudChildService.getChildren();
        getData.then(function (child) {
            $scope.children = child.data;
        }, function () {
            alert('Ошибка чтения записи');
        });
    }

    $scope.EditChild = function (child) {
        GetChildhoodNum();
        $scope.edit = true;
        $scope.save = false;
        var getData = crudChildService.getChild(child.Ind);
        getData.then(function (_child) {
            $scope.child = _child.data;
            $scope.Action = "Редактирование";
            $scope.divEdit = true;
        }, function () {
            alert('Ошибка чтения записи');
        });
    }

    $scope.AddChild = function () {
        var Child = $scope.child;
        Child.Ind = $scope.child.Ind;
        var getData = crudChildService.AddChild(Child);
        getData.then(function (msg) {
            if ($scope.childhoodNum)
                $scope.GetChildrenList(parseInt($scope.childhoodNum));
            else
                GetAllChildren();
            alert(msg.data);
            $scope.divEdit = false;
        }, function () {
            alert('Ошибка обновления записи');
        });
        $scope.save = false;
    }

    $scope.UpdateChild = function () {
        var Child = $scope.child;
        var getData = crudChildService.updateChild(Child);
        getData.then(function (msg) {
            if ($scope.childhoodNum)
                $scope.GetChildrenList(parseInt($scope.childhoodNum));
            else                
                GetAllChildren();
            alert(msg.data);
            $scope.divEdit = false;
        }, function () {
            alert('Ошибка добавления записи');
        });
        $scope.edit = false;
    }

    $scope.AddChildDiv = function () {
        $scope.child = null;
        GetChildhoodNum();
        $scope.edit = false;
        $scope.save = true;
        $scope.Action = "Добавление";
        $scope.divEdit = true;
    }

    $scope.DeleteChild = function (child) {
        var getData = crudChildService.DeleteChild(child.Ind);
        getData.then(function (msg) {
            alert(msg.data);
            $scope.divEdit = false;
            if ($scope.childhoodNum)
                $scope.GetChildrenList(parseInt($scope.childhoodNum));
            else
                GetAllChildren();
        }, function () {
            alert('Ошибка удаления записи');
        });
    }

    function GetChildhoodNum() {
        var childhoods = crudChildService.getChildhoodNum();
        childhoods.then(function (_num) {
            $scope.nums = _num.data;
        }, function () {
            alert('Ошибка чтения записи');
        });
    }

    $scope.Cancel = function () {
        $scope.divEdit = false;
    };
});

