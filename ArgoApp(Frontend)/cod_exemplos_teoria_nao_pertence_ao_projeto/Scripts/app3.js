var app = angular.module("argo", ["ui.router"]);
app.controller("MainController", function ($scope, $state) {
    $scope.irPara = "";
    $scope.$watch("irPara", function () {
        if ($scope.irPara == "ideias") {
            console.log("Bateu!");
            $state.go("ideias");
        }
    });
});

app.config(function($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise("/afazeres");
    $stateProvider.
        state("afazeres", {
            url: "/afazeres",
            templateUrl: "template/template1.html",
            controller: "MainController"
        })
        .state("ideias", {
            url: "/ideias",
            templateUrl: "template/template2.html",
            controller: "MainController"
            
        });

});