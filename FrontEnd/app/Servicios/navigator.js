myApp.value("tempStorage", {})
  .service("navigator", function ($location, tempStorage) {
      return {
          goTo: function (url, args) {
              tempStorage.args = args;
              $location.path(url);
          }
      };
  });

myApp.run(function ($rootScope, tempStorage) {
    $rootScope.$on('$routeChangeSuccess', function (evt, current, prev) {
        current.locals.$args = tempStorage.args;
    });
});

