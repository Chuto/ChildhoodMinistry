app.service("crudChildService", ["$http", function ($http) {

    this.getPageOfChildren = function (currentPage, pageSize) {
        var response = $http.post("/Child/GetPage", {
                page: currentPage, 
                pageSize: pageSize
            }
        );
        return response;
    };

    this.getChildById = function(childId) {
        var response = $http.post("/Child/GetChildById", {
            id: childId
        });
        return response;
    };

    this.updateChild = function(child) {
        var response = $http.post("/Child/UpdateChild", JSON.stringify(child));
        return response;
    };

    this.addChild = function(child) {
        var response = $http.post("/Child/AddChild", JSON.stringify(child));
        return response;
    };

    this.deleteChild = function(childId) {
        var response = $http.post("/Child/DeleteChild", {
            Id: childId
        });
        return response;
    };

    this.getChildhoods = function () {
        return $http.get("/Childhood/GetChildhoods");
    };
}]);
