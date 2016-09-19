var app = angular.module('agent', ['popDDL', 'angularUtils.directives.dirPagination', 'angular-loading-bar']);

app.factory('agentFactory', function ($http) {
    agentObj = {};

    agentObj.GetAll = function () {
        var agents;
        agents = $http({ method: 'Get', url: '/Admin/agents/GetJson' }).then(function (response) {
            return response.data;
        }, function (response) {
            var str;
            str = response.statusText;
            throw str;
        });
        return agents;
    };

    agentObj.GetById = function (agentId) {
        var agent;
        agent = $http({ method: 'Get', url: '/Admin/agents/Details/' + agentId }).then(function (response) {
            return response.data;
        }, function (response) {
            var str;
            str = response.statusText;
            throw str;
        });
        return agent;
    };

    agentObj.Create = function (agent) {
        var newAgent;

        newAgent = $http({
            method: 'Post', url: '/Admin/agents/Create/', data: agent
        }).then(function (response) {
            return response.data;
        }, function (response) {
            var str;
            str = response.statusText;
            throw str;
        });

        return newAgent;
    };

    agentObj.Update = function (agent) {
        var updAgent;
        //é necessario convertire il campo rowvers in json prima di passare l'oggetto a $http
        agent.rowvers = $.timeStampToBase64String(agent.rowvers);
        updAgent = $http({
            method: 'Post', url: '/Admin/agents/Edit/', data: agent,
        }).then(function (response) {
            return response.data;
        }, function (response) {
            var str;
            str = response.statusText;
            throw str;
        });

        return updAgent;
    };

    return agentObj;

});

app.controller("agentController", function ($scope, agentFactory) {

    GetAllAgents();
    $scope.agentToEdit = {};
    $scope.selected = {};

    function GetAllAgents() {
        agentFactory.GetAll().then(function (result) {
            for (var i = 0; i < result.length; i++) {
                //result è un array di oggetti, questo è il metodo per accedere alle proprietà di ciascun oggetto nelle'array
                result[i]["createdDate"] = result[i]["createdDate"] != null ? new Date(parseInt(result[i]["createdDate"].substr(6))) : null;
                result[i]["updatedDate"] = result[i]["updatedDate"] != null ? new Date(parseInt(result[i]["updatedDate"].substr(6))) : null;
                }
                $scope.agents = result;
        }, function (result) {           
            $scope.error = result;
            $("#msg_err").show();
        });
    };

    function GetById(Id) {
        agentFactory.GetById(Id).then(function (result) {
            result.createdDate = result.createdDate != null ? new Date(parseInt(result.createdDate.substr(6))) : null;
            result.updatedDate = result.updatedDate != null ? new Date(parseInt(result.updatedDate.substr(6))) : null;
            $scope.agentToEdit = result;
        }, function (result) {
            $scope.error = result;
            $("#msg_err").show();
        });
    };

    $scope.annullEdit = function () {

        $("#agentEditFormTb").toggle("hide");
        $scope.agentToEdit = {};
        $("#msg_err").hide();
        $("#msg_succ").hide();
        $("#msg_valid").hide();
    };

    $scope.annullCreate = function () {
        $("#agentFormTb").toggle("hide");
        $scope.agent = {};
        $("#msg_err").hide();
        $("#msg_succ").hide();
        $("#msg_valid").hide();
    }

    $scope.showAgentForm = function () {

        $scope.agent = {};
        if ($("#agentFormTb").is(":hidden")) {
            //$("#agentForm").show();
            $("#agentFormTb").toggle("show");
        }
        else {
            //$("#agentForm").hide();
            $("#agentFormTb").toggle("hide");
        }
        
        if (!$("#agentEditFormTb").is(":hidden")) {
            $("#agentEditFormTb").toggle("hide");
        }
    };

    $scope.showAgentEditForm = function (agent) {

        $scope.agentToEdit = angular.copy(agent);

        if ($("#agentEditFormTb").is(":hidden")) {

            $("#agentEditFormTb").toggle("show");
            GetById(agent.ID);
        }
        else {
            GetById(agent.ID);
        }

        if (!$("#agentFormTb").is(":hidden")) {
            $("#agentFormTb").toggle("hide");
        }
    };

    //$scope.getTemplate = function (agent) {
    //    if (agent == null) {
    //        return 'display';
    //    }
    //    else{
    //        if (agent.ID == $scope.selected.ID) {
    //            return 'edit';
    //        }
    //        else {
    //            return 'display';
    //        }
    //    }           
    //}

    $scope.Sort = function (col) {
        $scope.key = col;
        $scope.AscOrDesc = !$scope.AscOrDesc;
    };

   
    $scope.create = function (agent) {
        $("#msg_succ").hide();
        $("#msg_err").hide();
        $("#msg_valid").hide();

        if (!$("#agentEditFormTb").is(":hidden")) {
            $("#agentEditFormTb").toggle("hide");
        }
        
        var strValid;
        //validazione campi
        if (agent.agentName == null || agent.agentName == "") {
            strValid = "Inserire nome agente. ";
        }
        if (agent.agentUserID == null || agent.agentUserID == "") {
            if (strValid == null) {
                strValid = "Selezionare username. ";
            }
            else {
                strValid = strValid + "Selezionare username. ";
            }
        }

        if(strValid!=null) { 
            $scope.validation = strValid;
            $("#msg_valid").show();
        }
        else { //form valido
            //chiamata al service factory
            agentFactory.Create(agent).then(function (result) {
                strError = result.Message;
                if (strError == null) {
                    $scope.succ = "Agente " + result.agentName + " creato con successo";
                    $("#msg_succ").show();
                    $scope.agent = {};
                    GetAllAgents();
                }
                else {
                    $scope.error = strError;
                    $("#msg_err").show();
                }
            }, function (result) {
                $scope.error = result;
                $("#msg_err").show();
            });

        }
    };

    $scope.update = function (agent) {
        $("#msg_succ").hide();
        $("#msg_err").hide();
        $("#msg_valid").hide();

        if (!$("#agentFormTb").is(":hidden")) {
            $("#agentFormTb").hide();
        }

        var strValid;
        //validazione campi
        if (agent.agentName == null || agent.agentName=="") {
            strValid = "Inserire nome agente. ";
        }
        if (agent.agentUserID == null || agent.agentUserID == "") {
            if (strValid == null) {
                strValid = "Selezionare username. ";
            }
            else {
                strValid = strValid + "Selezionare username. ";
            }
            
        }

        if(strValid!=null) { 
            $scope.validation = strValid;
            $("#msg_valid").show();
        }
        else { //form valido
            agentFactory.Update(agent).then(function (result) {
                strError = result.Message;
                if (strError == null) {
                    $scope.succ = "Agente " + result.agentName + " modificato con successo";
                    $("#msg_succ").show();
                    $("#agentEditFormTb").toggle("hide");
                    $scope.agentToEdit = {};
                    GetAllAgents();
                }
                else {
                    $scope.error = strError;
                    $("#msg_err").show();
                }
            }, function (result) {
                $scope.error = result;
                $("#msg_err").show();
            });

        }
    }

});
