import angular from 'angular';
import uiRouter from 'angular-ui-router';
import riskHeaderComponent from './riskHeader.component';

export default angular.module('riskHeader', [
  uiRouter
])

.component('riskHeader', riskHeaderComponent)

.name;
