import angular from 'angular';
import uiRouter from 'angular-ui-router';
import mainHeadComponent from './mainHead.component';
import headerLink from './headerLink/headerLink';

export default angular.module('mainHead', [
  uiRouter,
  headerLink
])

.component('mainHead', mainHeadComponent)

.name;
