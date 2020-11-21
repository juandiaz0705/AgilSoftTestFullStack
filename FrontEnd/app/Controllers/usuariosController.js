var externo = false;
var id = 0;
myApp.controller('usuariosController', ['$scope', '$http', 'RutHelper', 'dataServiceGeneral', 'configuracion', 'ngDialog', function ($scope, $http, RutHelper, dataServiceGeneral, configuracion, ngDialog) {

    checkCookie();

    $scope.init = function () {

        $scope.itemsByPage = 15;
        $scope.displayedPages = 10;
        var request = { 'servicio': 'GetUsuarios'}
        dataServiceGeneral.execute(request).then(function (response) {
            $scope.lstUsuarios = response[0];
            $scope.lstPerfiles = response[1];
        });
    }

    $scope.Add = function () {
        $scope.usuario = "";
        $scope.email = "";
        $scope.perfil = "";
        $scope.vigencia = false;
        id = 0;
        ngDialog.open({
            template: 'app/views/dialogUsuario.html',
            className: 'ngdialog-theme-default',
            scope: $scope,
            width: '50%'
        });
    }

    $scope.Edit = function (row) {
        $scope.usuario = row.NOMBRE;
        $scope.email = row.USER_NAME;
        $scope.perfil = { 'ID': row.PERFIL, 'DESCRIPCION': row.PERFIL_DESCRIPCION };
        $scope.vigencia = (row.ESTADO == '1');
        id = row.ID;
        ngDialog.open({
            template: 'app/views/dialogUsuario.html',
            className: 'ngdialog-theme-default',
            scope: $scope,
            width: '50%'
        });
    }

    $scope.grabarUsuarios = function () {
        var request = { 'servicio': 'GrabarUsuario', params: [id, $scope.usuario, $scope.email, $scope.password, $scope.perfil.ID, ($scope.vigencia) ? 1 : 0] }
        dataServiceGeneral.execute(request).then(function (response) {
            location.href = '#Usuarios';
            ngDialog.close();
        });
    }

    $scope.AddPerfil = function () {
        $scope.perfilModal = "";
        ngDialog.open({
            template: 'app/views/dialogPerfiles.html',
            className: 'ngdialog-theme-default',
            scope: $scope,
            width: '25%'
        });
    }

    $scope.grabarPerfil = function () {
        var request = { 'servicio': 'GrabiarPerfil', params: [0, $scope.perfilModal] }
        dataServiceGeneral.execute(request).then(function (response) {
            location.href = '#Usuarios';
            ngDialog.close();
        });
    }

    $scope.init();

}]);

