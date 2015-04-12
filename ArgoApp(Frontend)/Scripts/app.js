
"use sctrict";

var app = angular.module("argo", ["ui.router"]);
app.controller("MainController", function ($scope, $state, $http, $timeout) {

    $http.get("http://localhost:52289/api/funcionario").success(function (data) {
        $scope.funcionarios = data;
    });

    $scope.mensagemDeRetorno = "Mensagem Default";
    $scope.mostrarAlertSucesso = false;
    $scope.mostrarAlertErro = false;


    $scope.$watch("irPara", function (novo, antigo) {
        if ($scope.irPara == "contato") {;
            $state.go("contato");
        }
        if ($scope.irPara == "home") {
            $state.go("home");
        }
    });


    $scope.elementoSelecionado = null;
    $scope.novoFuncionario = null;
    $scope.solicitacaoDeContato = null;

    $scope.editarClicado = function (funcionario, index) {
        $scope.elementoSelecionado = funcionario;
    }

    $scope.excluirClicado = function (funcionario, index) {
        $scope.elementoSelecionado = funcionario;
    }

    $scope.removerSelecionado = function (elem) {
        $http.delete("http://localhost:52289/api/funcionario/" + elem.Id).success(function (data) {
            console.log("Elemento deletado com sucesso!");
            $http.get("http://localhost:52289/api/funcionario").success(function (dados) {
                $scope.funcionarios = dados;
                $scope.mensagemDeRetorno = "Elemento excluído com sucesso!";
                $scope.mostrarAlertSucesso = true;
                $timeout(function () {
                    $scope.mensagemDeRetorno = "";
                    $scope.mostrarAlertSucesso = false;
                }, 3000);
            });
        }).error(function (erro) {
            console.log("Erro ao apagar o elemento!");
        });
    }

    $scope.editarSelecionado = function (elem) {
        console.log(elem);
        $http.put("http://localhost:52289/api/funcionario", elem, { headers: { "Content-Type": "application/json" } }).success(function (data) {
            $http.get("http://localhost:52289/api/funcionario").success(function (dados) {
                $scope.funcionarios = dados;
                $scope.mensagemDeRetorno = "Elemento Atualizado com Sucesso!";
                $scope.mostrarAlertSucesso = true;
                $timeout(function () {
                    $scope.mensagemDeRetorno = "";
                    $scope.mostrarAlertSucesso = false;
                }, 3000);
            });
        }).error(function (error) {
            $scope.mensagemDeRetorno = "Erro ao atualizar o elemento";
            $scope.mostrarAlertErro = true;
            $timeout(function () {
                $scope.mensagemDeRetorno = "";
                $scope.mostrarAlertErro = false;
            }, 3000);
        });
    }

    $scope.salvarNovoFuncionario = function (elem) {
        $http.post("http://localhost:52289/api/funcionario", elem, { headers: { "Content-Type": "application/json" } }).success(function (data) {
            $http.get("http://localhost:52289/api/funcionario").success(function (dados) {
                $scope.funcionarios = dados;
                $scope.mensagemDeRetorno = "Elemento criado com sucesso!";
                $scope.mostrarAlertSucesso = true;
                $timeout(function () {
                    $scope.mensagemDeRetorno = "";
                    $scope.mostrarAlertSucesso = false;
                }, 3000);
            });
        }).error(function (error) {
            $scope.mensagemDeRetorno = "Erro ao criar novo elemento";
            $scope.mostrarAlertErro = true;
            $timeout(function () {
                $scope.mensagemDeRetorno = "";
                $scope.mostrarAlertErro = false;
            }, 3000);
        });
    }

    $scope.salvarContato = function (contato) {
        $http.post("http://localhost:52289/api/contato", contato, { headers: { "Content-Type": "application/json" } }).success(function (data) {


            $scope.mensagemDeRetorno = "Contato Enviado com sucesso!";
            $scope.mostrarAlertSucesso = true;
            $timeout(function () {
                $scope.mensagemDeRetorno = "";
                $scope.mostrarAlertSucesso = false;
            }, 3000);

        }).error(function (error) {
            $scope.mensagemDeRetorno = "Erro ao criar novo elemento";
            $scope.mostrarAlertErro = true;
            $timeout(function () {
                $scope.mensagemDeRetorno = "";
                $scope.mostrarAlertErro = false;
            }, 3000);
        });
    }

});

app.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise("/home");
    $stateProvider
        .state("home", {
            url: "/home",
            templateUrl: "Partials/home.html",
            controller: "MainController"
        })
        .state("contato", {
            url: "/contato",
            templateUrl: "Partials/contato.html",
            controller: "MainController"
        });
});