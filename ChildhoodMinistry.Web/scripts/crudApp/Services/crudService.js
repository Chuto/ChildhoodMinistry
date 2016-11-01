app.service("crudService", function ($http) {
    this.sendRequest = function (method, url, data) {
        var response = $http({
            method: method,
            url: url,
            data: JSON.stringify(data),
            dataType: "json"
        });
        return response;
    }
});
