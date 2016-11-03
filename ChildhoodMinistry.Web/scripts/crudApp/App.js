angular.module("lodash", [])
   .factory('_', ['$window', function ($window) {
       return $window._;
   }]);

var app = angular.module("mvcCRUDApp", ["lodash"]);