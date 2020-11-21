var externo = false;
myApp.controller('loginController', ['$scope', '$http', 'RutHelper', 'dataServiceGeneral', 'configuracion', 'ngDialog', function ($scope, $http, RutHelper, dataServiceGeneral, configuracion, ngDialog) {

    if (getCookie("userPerfil") != "") {
        location.href = '#Tareas';
    }
    $scope.Ingresar = function () {
        if (typeof $scope.email === 'undefined') {
            $("#MensajeError").text('Debe inficar un Email.')
            return false;
        }
        if (typeof $scope.clave === 'undefined') {
            $("#MensajeError").text('Debe inficar la clave.')
            return false;
        }

        var request = { 'servicio': 'GetLogin', params: [$scope.email, $scope.clave] }
        dataServiceGeneral.execute(request).then(function (response) {
            console.log(response.length)
            if (response.length == 0) {
                $("#MensajeError").text('Usuario no encontrado.')
                return false;
            } else {
                $scope.Perfil = response[0].PERFIL;
                $scope.IdUsuario = response[0].ID;
                $scope.NombreUsuario = response[0].NOMBRE;
                setCookie("username", response[0].NOMBRE, 365)
                setCookie("userPerfil", response[0].PERFIL, 365)
                setCookie("userID", response[0].ID, 365)
                location.reload();
                
                //setCookie("username", response[0].NOMBRE, 365)
                //setCookie("userPerfil", response[0].PERFIL, 365)
                //setCookie("userID", response[0].ID, 365)
                //location.reload();
                //$scope.Perfil = response[0].ID_PERFIL;
                //location.href = '#Monitoreo';
            }
        });
    }
}]);

