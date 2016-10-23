import angular from 'angular';
import uiRouter from 'angular-ui-router';
import riskCardComponent from './riskCard.component';

export default angular.module('riskCard', [
  uiRouter
])

.component('riskCard', riskCardComponent)

.name;
