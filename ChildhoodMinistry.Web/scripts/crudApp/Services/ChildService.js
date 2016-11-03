app.service("crudChildService", ["$http", function ($http) {

    this.getPageOfChildren = function (currentPage, pageSize) {
        var response = $http({
            method: "post",
            url: "/Child/GetPage",
            params: {
                page: currentPage, 
                pageSize: pageSize
            }
        });
        return response;
    };

    this.getChildById = function(childId) {
        var response = $http({
            method: "post",
            url: "/Child/GetChildById",
            params: {
                id: childId
            }
        });
        return response;
    };

    this.updateChild = function(child) {
        var response = $http({
            method: "post",
            url: "/Child/UpdateChild",
            data: JSON.stringify(child),
            dataType: "json"
        });
        return response;
    };

    this.addChild = function(child) {
        var response = $http({
            method: "post",
            url: "/Child/AddChild",
            data: JSON.stringify(child),
            dataType: "json"
        });
        return response;
    };

    this.deleteChild = function(childId) {
        var response = $http({
            method: "post",
            url: "/Child/DeleteChild",
            params: {
                id: JSON.stringify(childId)
            }
        });
        return response;
    };

    this.getChildhoods = function () {
        return $http.get("/Childhood/GetChildhoods");
    };
}]);
