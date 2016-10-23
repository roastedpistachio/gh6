import angular from 'angular';
import uiRouter from 'angular-ui-router';
import Common from './common/common';
import Components from './components/components';
import Providers from './providers/providers';
import AppComponent from './app.component';
import uiBootstrap from 'angular-bootstrap-npm';
import angularMoment from 'angular-moment';
import momentTimezone from 'moment-timezone';
import 'normalize.css';

angular.module('app', [
    uiBootstrap,
    uiRouter,
    Common,
    Components,
    Providers,
    angularMoment
  ])
  .config(($locationProvider) => {
    "ngInject";
    // @see: https://github.com/angular-ui/ui-router/wiki/Frequently-Asked-Questions
    // #how-to-configure-your-server-to-work-with-html5mode
    $locationProvider.html5Mode(true).hashPrefix('!');
  })

  .component('app', AppComponent);
