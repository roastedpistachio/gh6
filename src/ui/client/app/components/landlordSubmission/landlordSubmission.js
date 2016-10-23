import angular from 'angular';
import uiRouter from 'angular-ui-router';
import landlordSubmissionComponent from './landlordSubmission.component';

export default angular.module('landlordSubmission', [
  uiRouter
])

.component('landlordSubmission', landlordSubmissionComponent)

.config(($stateProvider) => {
  "ngInject";

  $stateProvider
    .state('landlordSubmission', {
      url: '/landlord-submission',
      component: 'landlordSubmission'
    });
})

.name;
