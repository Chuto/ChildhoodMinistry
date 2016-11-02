app.service("crudChildService", function ($http) {

    this.GetPageOfChild = function (currentPage, pageSize) {
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

    this.GetChildById = function(childId) {
        var response = $http({
            method: "post",
            url: "/Child/GetChildById",
            params: {
                id: childId
            }
        });
        return response;
    };

    this.UpdateChild = function(child) {
        var response = $http({
            method: "post",
            url: "/Child/UpdateChild",
            data: JSON.stringify(child),
            dataType: "json"
        });
        return response;
    };

    this.AddChild = function(child) {
        var response = $http({
            method: "post",
            url: "/Child/AddChild",
            data: JSON.stringify(child),
            dataType: "json"
        });
        return response;
    };

    this.DeleteChild = function(childId) {
        var response = $http({
            method: "post",
            url: "/Child/DeleteChild",
            params: {
                id: JSON.stringify(childId)
            }
        });
        return response;
    };

    this.GetChildhoods = function () {
        return $http.get("/Childhood/GetChildhoods");
    };
});
