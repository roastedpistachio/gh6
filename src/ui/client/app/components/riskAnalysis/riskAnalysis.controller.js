import modalTemplate from './assignmentModal/assignmentModal.html'
import modalController from './assignmentModal/assignmentModal.controller'

class RiskAnalysisController {
  constructor(Risks, $uibModal, Clients) {
    'ngInject';
    this.name = 'riskAnalysis';
    this.activeRiskFilter = 'MY_AREA';
    this.Risks = Risks;
    this.modal = $uibModal;
    this.Clients = Clients;
  }
  updateFilter(filter) {
    this.activeRiskFilter = filter;
  }
  updateSearch(query) {
    this.search = {
      client: {
        name: query
      }
    }
  }
  getFilteredRiskCount(filter) {
    return this.risks.filter(risk => risk.caseStatus === filter).length;
  }
  updateStatus(status, risk) {
    const updateStatus = () => {
      this.Risks.update(Object.assign({}, risk, { caseStatus: status })).then(() => {
          risk.caseStatus = status
      })
    }

    if (status === 'Awaiting Initial Contact') {
      const modalInstance = this.modal.open({
        animation: true,
        controller: modalController,
        template: modalTemplate,
        controllerAs: '$ctrl',
        backdrop: 'static',
        keyboard: false,
        resolve: {
          risk: () => angular.copy(risk),
          matches: () => this.Clients.query(risk).then(res => res.data)
        }
      })
      modalInstance.result.then(() => {
        updateStatus()
      })
    } else {
      updateStatus()
    }

  }
}

export default RiskAnalysisController;
