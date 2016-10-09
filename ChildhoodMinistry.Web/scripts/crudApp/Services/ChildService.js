app.service("crudChildService", function ($http) {

    this.getChildren = function () {
        return $http.get("/Child/GetAllChildren");
    };

    this.getChild = function (childId) {
        var response = $http({
            method: "post",
            url: "/Child/GetChildById",
            params: {
                id: JSON.stringify(childId)
            }
        });
        return response;
    }

    this.updateChild = function (child) {
        var response = $http({
            method: "post",
            url: "/Child/UpdateChild",
            data: JSON.stringify(child),
            dataType: "json"
        });
        return response;
    }

    this.AddChild = function (child) {
        var response = $http({
            method: "post",
            url: "/Child/AddChild",
            data: JSON.stringify(child),
            dataType: "json"
        });
        return response;
    }

    this.DeleteChild = function (childId) {
        var response = $http({
            method: "post",
            url: "/Child/DeleteChild",
            params: {
                id: JSON.stringify(childId)
            }
        });
        return response;
    }

    this.getChildhoodNum = function () {
        return $http.get("/Childhood/GetChildhoodNum");
    };
});
