import angular from 'angular';
import uiRouter from 'angular-ui-router';
import riskModalComponent from './riskModal.component';

export default angular.module('riskModal', [
  uiRouter
])

.component('riskModal', riskModalComponent)

.name;
