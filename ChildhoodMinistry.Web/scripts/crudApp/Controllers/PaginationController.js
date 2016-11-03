app.controller("PagingController", ["_",function (_) {
    var vmPage = this;
    var startPage, endPage;

    if (vmPage.totalPages <= 10) {
        startPage = 1;
        endPage = vmPage.totalPages;
    } else {
        if (vmPage.currentPage <= 6) {
            startPage = 1;
            endPage = 10;
        } else if (vmPage.currentPage + 4 >= vmPage.totalPages) {
            startPage = vmPage.totalPages - 9;
            endPage = vmPage.totalPages;
        } else {
            startPage = vmPage.currentPage - 5;
            endPage = vmPage.currentPage + 4;
        }
    }

    vmPage.pages = _.range(startPage, endPage + 1);

    vmPage.getPage = function (num) {
        vmPage.loadPage({ page: num })
    };
}]);