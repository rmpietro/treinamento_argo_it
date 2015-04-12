var app = angular.module("argo", []);

app.controller("MainController", function($scope) {
    
});

app.directive("funcionario", function() {

    return {
        restrict: "E",
        templateUrl: "template/funcionario.html",
        link: function(scope, element, attrs) {
            scope.nome = attrs.nome;
            scope.email = attrs.email;
        }
    }
});