import angular from 'angular'
import uiRouter from 'angular-ui-router'
import riskAnalysisComponent from './riskAnalysis.component'

import riskCard from './riskCard/riskCard'
import riskHeader from './riskHeader/riskHeader'
import riskModal from './riskModal/riskModal'
import newRisk from './newRisk/newRisk'

export default angular.module('riskAnalysis', [
  uiRouter,
  riskHeader,
  riskCard,
  newRisk,
  riskModal
])

.component('riskAnalysis', riskAnalysisComponent)

.filter('statusEquals', () => (risks, status) =>
  risks.filter(risk => risk.caseStatus === status))

.config($stateProvider => {
  'ngInject';

  $stateProvider
    .state('risks', {
      url: '/risks',
      component: 'riskAnalysis',
      resolve: {
        risks: Risks => {
          'ngInject'
          return Risks.getAll().then(res => res.data);
        }
      }
    })
    .state('risks.risk', {
      url: '/risk/:id',
      component: 'riskModal',
      resolve: {
        risk: (Risks, $stateParams) => {
          'ngInject';
          return Risks.getOne($stateParams.id).then(res => res.data);
        }
      }
    })
    .state('risks.new', {
      url: '/new',
      component: 'newRisk'
    })
})

.name
