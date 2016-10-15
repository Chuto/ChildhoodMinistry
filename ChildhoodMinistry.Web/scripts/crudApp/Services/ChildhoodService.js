app.service("crudChildhoodService", function ($http) {

    this.getChildhoods = function () {
        return $http.get("/Childhood/GetAllChildhoods");
    };

    this.getChildhood = function (childhoodId) {
        var response = $http({
            method: "post",
            url: "/Childhood/GetChildhoodById",
            params: {
                id: JSON.stringify(childhoodId)
            }
        });
        return response;
    };

    this.updateChildhood = function (childhood) {
        var response = $http({
            method: "post",
            url: "/Childhood/UpdateChildhood",
            data: JSON.stringify(childhood),
            dataType: "json"
        });
        return response;
    };

    this.getChildrenList = function (childhoodId) {
        var response = $http({
            method: "post",
            url: "/Child/GetChildByChildhoodId",
            params: {
                id: JSON.stringify(childhoodId)
            }
        });
        return response;
    };

    this.AddChildhood = function (childhood) {
        var response = $http({
            method: "post",
            url: "/Childhood/AddChildhood",
            data: JSON.stringify(childhood),
            dataType: "json"
        });
        return response;
    };

    this.DeleteChildhood = function (childhoodId) {
        var response = $http({
            method: "post",
            url: "/Childhood/DeleteChildhood",
            params: {
                id: JSON.stringify(childhoodId)
            }
        });
        return response;
    };
});