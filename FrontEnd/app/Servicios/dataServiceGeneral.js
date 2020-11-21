myApp.factory('dataServiceGeneral', ['$http', 'configuracion', function ($http, configuracion) {

    var urlServidor = configuracion.urlServidor;
    var fac = {};

    fac.executePOST = function (request)
    {
        var urlTarget = urlServidor + '/api/data/' + request.servicio;
        console.log('urlTarget=' + urlTarget);

        return $http.post(urlTarget, request.data).success(function (response, status)
        {
            return JSON.parse(response);
        }).error(function (error, status) {
            console.log(error);
            alert(error.ExceptionMessage);
        });
    };

    fac.execute = function (request)
    {
        var urlTarget = urlServidor + '/api/data/' + request.servicio;

        $.each(request.params, function (index, value) {
            console.log({ 'index': index, 'value': value });
            urlTarget += '/' + value;
        });

        console.log('urlTarget=' + urlTarget);

        return $http.get(urlTarget).then(function (response) {
            return JSON.parse(response.data);
        });
    };

    fac.IsAdmin = function () {

        var url = urlServidor + '/api/data/isAdmin';
        return $http.get(url).success(function (data, status) {
            return (data);
        }).error(function (error, status) {
            console.log(error);
            alert(error.Message);
        });
    };

    fac.IsPiloto = function () {

        var url = urlServidor + '/api/data/isPiloto';
        //alert('url->' + url);
        return $http.get(url).success(function (data, status) {
            return (data);
        }).error(function (error, status) {
            console.log(error);
            alert(error.Message);
        });
    };

    fac.RegistraAcceso = function () {
        var url = urlServidor + '/api/data/registraAcceso';
        //alert('url->' + url);
        return $http.post(url).success(function (data, status) {
            return (data);
        }).error(function (error, status) {
            console.log(error);
            alert(error.Message);
        });
    };

    fac.ObtenerNombreEjecutivo = function () {
        var url = urlServidor + '/api/data/getNombreEjecutivo';
        return $http.get(url).then(function (response) {
            var nombre = response.data;
            return nombre;
        })
    };

    fac.ObtenerCodigoEjecutivo = function () {
        var url = urlServidor + '/api/data/getCodigoEjecutivo';
        console.log(url);
        return $http.get(url).then(function (response) {
            return response.data;
        })
    };

    fac.AddSol = function (data) {
        return $http.post(urlServidor + '/api/General/', data, {
            withCredentials: true,
            headers: { 'Content-Type': undefined },
            transformRequest: angular.identity
        });
    };

    return fac;
}]);