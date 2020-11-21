showLoader = function () {
    $.blockUI({
        message: 'Cargando ...',
        css: {
            border: 'none',
            padding: '15px',
            backgroundColor: '#000',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            opacity: .5,
            color: '#fff'
        }
    });
}

hideLoader = function () {
    $.unblockUI();
}

var myApp = angular.module('myApp', ['smart-table', 'fupApp', 'ngRoute', 'ngDialog', 'platanus.rut']);

//config routing
myApp.config(function ($routeProvider) {//, $locationProvider) {
    $routeProvider
        .when('/', {
            redirectTo: '/Login'
        })
        .when('/Tareas', {
            redirectTo: '/Tareas'
        })
        .when('/Tareas', {
            templateUrl: '/app/views/Tareas.html',
            controller: 'tareasController'
        })
        .when('/Transacciones', {
            templateUrl: '/app/views/Transacciones.html',
            controller: 'paymentController'
        })
        .when('/Servicios', {
            templateUrl: '/app/views/Servicios.html',
            controller: 'servicioController'
        })
        .when('/Grupos', {
            templateUrl: '/app/views/GruposServicios.html',
            controller: 'gruposController'
        })
        .when('/Recaudaciones', {
            templateUrl: '/app/views/Recaudaciones.html',
            controller: 'recaudacionController'
        })
        .when('/Login', {
            templateUrl: '/app/views/Login.html',
            controller: 'loginController'
        })
        .when('/Usuarios', {
            templateUrl: '/app/views/Usuarios.html',
            controller: 'usuariosController'
        })
        .when('/Comision', {
            templateUrl: '/app/views/Comision.html',
            controller: 'comisionController'
        })
        .when('/ServiciosTerminal', {
            templateUrl: '/app/views/ServiciosTerminales.html',
            controller: 'serviciosTerminalesController'
        })
        .when('/Proveedores', {
            templateUrl: '/app/views/Proveedores.html',
            controller: 'proveedoresController'
        })
        .when('/Convenio', {
            templateUrl: '/app/views/Convenios.html',
            controller: 'convenioController'
        })

    //$locationProvider.html5Mode({enabled:true, requireBase: false});
});

myApp.controller('indexController', ['$scope', '$http', 'dataServiceGeneral', 'configuracion', 'ngDialog', function ($scope, $http, dataServiceGeneral, configuracion, ngDialog) {

    $scope.localHost = configuracion.urlSitioWeb;
    $scope.urlServidor = configuracion.urlServidor;

    $scope.showLoader = function () {
        $.blockUI({
            message: 'Cargando ...',
            css: {
                border: 'none',
                padding: '15px',
                backgroundColor: '#000',
                '-webkit-border-radius': '10px',
                '-moz-border-radius': '10px',
                opacity: .5,
                color: '#fff'
            }
        });
    }

    $scope.hideLoader = function () {
        $.unblockUI();
    }

    $scope.getURLParams = function () {
        try {
            var queries = {};
            $.each(document.location.search.substr(1).split('&'), function (c, q) {
                var i = q.split('=');
                queries[i[0].toString()] = i[1].toString();
            });
            return queries;
        } catch (ex) {
            return null;
        }
    }

    $scope.normalDialog = function (title, message) {
        $scope.modalTitle = title;
        $scope.modalMessage = message;
        ngDialog.open({
            template: 'app/views/dialogNormal.html',
            className: 'ngdialog-theme-default',
            scope: $scope,
        });
    };

    $scope.errorDialog = function (title, message) {
        $scope.modalTitle = title;
        $scope.modalMessage = message;
        ngDialog.open({
            template: 'app/views/dialogError.html',
            className: 'ngdialog-theme-default',
            scope: $scope,
        });
    };

    $scope.confirmDialog = function (title, message, data, confirmFunction, cancelFunction) {
        $scope.modalTitle = title;
        $scope.modalMessage = message;
        ngDialog.openConfirm({
            template: 'app/views/dialogConfirm.html',
            scope: $scope,
        }).then(function (success) {
            // Success logic here
            confirmFunction(data);
        }, function (error) {
            // Error logic here
            cancelFunction(data);
        });
    }

    $scope.getFecha = function (fecha) {

        var _fecha = new Date();

        if (fecha != null) {
            _fecha = new Date(fecha);
        }

        var fechaTime = _fecha.getTime();

        if (fechaTime == 0 || isNaN(fechaTime)) {
            return null;
        }
        var result = padLeft(_fecha.getDate().toString(), 2) + '-' + padLeft((_fecha.getMonth() + 1).toString(), 2) + '-' + _fecha.getFullYear().toString()
        return result;
    }

    $scope.getFechaINT = function (fecha) {
        var result = $scope.getFecha2DB(fecha)
        return parseInt(result);
    }

    $scope.getFecha2DB = function (fecha) {

        var _fecha = new Date();

        if (fecha != null) {
            _fecha = new Date(fecha);
        }

        var fechaTime = _fecha.getTime();

        if (fechaTime == 0 || isNaN(fechaTime)) {
            return null;
        }
        var result = _fecha.getFullYear().toString() + '-' + padLeft((_fecha.getMonth() + 1).toString(), 2) + '-' + padLeft(_fecha.getDate().toString(), 2)
        return result;
    }

    $scope.getFechaANSI = function (fecha) {

        var _fecha = new Date();

        if (fecha != null) {
            _fecha = new Date(fecha);
        }

        var fechaTime = _fecha.getTime();

        if (fechaTime == 0 || isNaN(fechaTime)) {
            return null;
        }
        var result = _fecha.getFullYear().toString() + padLeft((_fecha.getMonth() + 1).toString(), 2) + padLeft(_fecha.getDate().toString(), 2)
        return result;
    }

    //if (typeof $scope.Perfil === "undefined") {
    //    $("#headerApp").hide();
    //    location.href = '#Login';
    //}

    var username = getCookie("userPerfil");
    if (username != "") {
        $("#headerApp").show();
        $scope.Perfil = getCookie("userPerfil");
        $scope.IdUsuario = getCookie("userID");
    } else {
        $("#headerApp").hide();
        location.href = '#Login';
    }

    //dataServiceGeneral.ObtenerNombreEjecutivo().then(function (response) {
    //    //response = 'PABARC60';
    //    $scope.login = response;
    //    $scope.fullNameUser = response;

    //});
}]);


function checkCookie() {
    var username = getCookie("username");
    if (username != "") {
        $("#headerApp").show();
    } else {
        $("#headerApp").hide();
        location.href = '#Login';
    }
}

function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}



