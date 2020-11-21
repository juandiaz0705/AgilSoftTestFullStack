var myApp = angular.module('documentos', ['pdf', 'ngSanitize']);
myApp.controller('pdfController', function ($scope, dataServiceGeneral, $sce, configuracion) {
   
$scope.urlServidor = configuracion.urlServidor;

    console.log($scope.urlServidor);
    var idGeneracion = sessionStorage.getItem('idGeneracion');
    console.log(idGeneracion);

     dataServiceGeneral.ObtenerRutaPdf(idGeneracion).then(function (response) {

        $scope.RutaPdf = response;
        console.log($scope.RutaPdf);
        $scope.trustSrc = function(src) {
        return $sce.trustAsResourceUrl(src);
    };

     $scope.movie = { src: $scope.urlServidor + '/' + $scope.RutaPdf + '/OUTPUT', title: "Documentación Normativa" };
    // $scope.movie = { src: 'http://localhost:25419/api/data/getArchivo', title: "Documentación Normativa" };
    // $scope.movie = { src: $scope.urlServidor + '/' + $scope.RutaPdf, title: "Documentación Normativa" };
 });
});