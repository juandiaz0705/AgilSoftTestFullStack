var externo = false;
var id = 0;
myApp.controller('tareasController', ['$scope', '$http', 'RutHelper', 'dataServiceGeneral', 'configuracion', 'ngDialog', function ($scope, $http, RutHelper, dataServiceGeneral, configuracion, ngDialog) {

    checkCookie();

    $scope.init = function () {

        $scope.itemsByPage = 15;
        $scope.displayedPages = 10;
        var request = { 'servicio': 'GetTareas', params: [$scope.IdUsuario]}
        dataServiceGeneral.execute(request).then(function (response) {
            $scope.lstTareas = response[0];
            $scope.lstUsuarios = response[1];
        });
    }

    $scope.Add = function () {
        id = 0;
        $scope.nombre = "";
        $scope.descripcion = "";
        $scope.usuarioAsignar = "";
        ngDialog.open({
            template: 'app/views/dialogTareas.html',
            className: 'ngdialog-theme-default',
            scope: $scope,
            width: '50%'
        });
    }

    $scope.RealizarTarea = function (row) {
        var request = { 'servicio': 'GrabarTarea', params: [row.ID, row.NOMBRE, '2',  row.DESCRIPCION, row.USUARIO_ASIGNADO] }
        dataServiceGeneral.execute(request).then(function (response) {
            location.href = '#Tareas';
            ngDialog.close();
        });
    }

    $scope.EliminarTarea = function (row) {
        var request = { 'servicio': 'GrabarTarea', params: [row.ID, row.NOMBRE, '0', row.DESCRIPCION, row.USUARIO_ASIGNADO] }
        dataServiceGeneral.execute(request).then(function (response) {
            location.href = '#Tareas';
            ngDialog.close();
        });
    }

    $scope.Edit = function (row) {
        id = row.ID;
        $scope.nombre = row.NOMBRE;
        $scope.descripcion = row.DESCRIPCION;
        $scope.usuarioAsignar = { 'ID': row.USUARIO_ASIGNADO, 'NOMBRE': row.NOMBRE_USUARIO };
        ngDialog.open({
            template: 'app/views/dialogTareas.html',
            className: 'ngdialog-theme-default',
            scope: $scope,
            width: '50%'
        });
    }

    $scope.grabar = function () {
        var request = { 'servicio': 'GrabarTarea', params: [id, $scope.nombre, '1', $scope.descripcion, $scope.usuarioAsignar.ID] }
        dataServiceGeneral.execute(request).then(function (response) {
            location.href = '#Tareas';
            ngDialog.close();
        });
    }


    $scope.init();

}]);

