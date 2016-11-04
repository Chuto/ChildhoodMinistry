app.service("crudChildhoodService", ["$http", function ($http) {

    this.getPageOfChildhoods = function (currentPage, pageSize) {
        var response = $http.post("/Childhood/GetPage", {
                page: currentPage,
                pageSize: pageSize
        });
        return response;
    };

    this.getChildhoods = function () {
        var response = $http.get("/Childhood/GetChildhoods");
        return response;
    };

    this.getChildhood = function (childhoodId) {
        var response = $http.post("/Childhood/GetChildhoodById", {
            id:childhoodId
        });
        return response;
    }

    this.updateChildhood = function (childhood) {
        var response = $http.post("/Childhood/UpdateChildhood", childhood);
        return response;
    }

    this.getChildrenList = function (childhoodId) {
        var response = $http.post("/Child/GetChildByChildhoodNum", {
            id: childhoodId
        });
        return response;
    }

    this.addChildhood = function (childhood) {
        var response = $http.post("/Childhood/AddChildhood", childhood);
        return response;
    }

    this.deleteChildhood = function (childhoodId) {
        var response = $http.post("/Childhood/DeleteChildhood", {
            id: childhoodId
        });
        return response;
    }
}]);