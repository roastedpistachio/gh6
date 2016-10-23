import angular from 'angular';
import uiRouter from 'angular-ui-router';
import fileImportComponent from './fileImport.component';


export default angular.module('fileImport', [
  uiRouter, 'app.providers'
])

.component('fileImport', fileImportComponent)

.directive('file', function () {
    return {
        scope: {
            file: '='
        },
        link: function (scope, el, attrs) {
            el.bind('change', function (event) {
                var file = event.target.files[0];
                scope.file = file ? file : undefined;
                scope.$apply();
            });
        }
    };
})
.config(($stateProvider) => {
  "ngInject";

  $stateProvider
    .state('import', {
      url: '/import',
      component: 'fileImport'
    });
})

.name;
