import angular from 'angular';
import uiRouter from 'angular-ui-router';
import headerLinkComponent from './headerLink.component';

export default angular.module('headerLink', [
  uiRouter
])

.component('headerLink', headerLinkComponent)

.name;
