
//services
myApp.factory('dataServiceOfertas', ['$http', 'configuracion', function ($http, configuracion) {
    var urlServidor = configuracion.urlServidor;
    var fac = [];

    fac.grabarEstado = function (data) {
        var urlTarget = urlServidor + '/api/data/grabarEstado';
        console.log('urlTarget=' + urlTarget);

        return $http.post(urlTarget, data).success(function (response, status) {
            return (response);
        }).error(function (error, status) {
            console.log(error);
            alert(error.Message);
        });
    };

    fac.grabarVenta = function (data) {
        var urlTarget = urlServidor + '/api/data/grabarVenta';
        console.log('urlTarget=' + urlTarget);

        return $http.post(urlTarget, data).success(function (response, status) {
            return (response);
        }).error(function (error, status) {
            console.log(error);
            alert(error.Message);
        });
    };

    fac.ListaVentaCliente = function (rut)
    {
        var urlTarget = urlServidor + '/api/data/ListaVentaCliente/' + rut;
        console.log('urlTarget=' + urlTarget);

        return $http.get(urlTarget).then(function (response) {
            //console.log(response.data);
            return response.data;
        });
    };

    fac.grabarDataArchivo = function (data)
    {
        var urlTarget = urlServidor + '/api/data/grabarDataArchivo';
        console.log('urlTarget=' + urlTarget);

        return $http.post(urlTarget, data).success(function (response, status) {
            return (response);
        }).error(function (error, status) {
            console.log(error);
            alert(error.Message);
        });
    };

    fac.AddDeal = function (data) {
        return $http.post(urlServidor + '/api/Documentos/', data, {
            withCredentials: true,
            headers: { 'Content-Type': undefined },
            transformRequest: angular.identity
        });
    };

    return fac;
}
]);