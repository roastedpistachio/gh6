import angular from 'angular';
import uiRouter from 'angular-ui-router';
import newRiskComponent from './newRisk.component';

export default angular.module('newRisk', [
  uiRouter
])

.component('newRisk', newRiskComponent)

.name;
