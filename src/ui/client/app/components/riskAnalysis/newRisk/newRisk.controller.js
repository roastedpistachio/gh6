import template from './newRisk.html'

class NewRiskModalController {
  constructor($uibModalInstance, Risks) {
    'ngInject';
    this.modalInstance = $uibModalInstance
    this.Risks = Risks
    this.client = {
      name: null,
      dateOfBirth: null,
      address: {
        address: null,
        city: null,
        state: 'MO'
      }
    }
  }
  get canSubmit() {
    return this.client.name && this.risk && this.riskFactor;
  }
  importData() {
    this.modalInstance.close('import')
  }
  close() {
    this.modalInstance.close()
  }
  save() {
    this.Risks.create({
      client: this.client,
      risk: this.risk,
      riskFactor: this.riskFactor,
      caseStatus: 'Assignment',
      created: new Date(),
    }).then(() => this.modalInstance.close())
  }
}

export default class newRiskController {
  constructor($uibModal, $state, Risks) {
    'ngInject';
    this.modal = $uibModal
    this.$state = $state
    this.Risks = Risks
  }
  $onInit() {
    const modalInstance = this.modal.open({
      animation: true,
      controller: NewRiskModalController,
      template: template,
      controllerAs: '$ctrl',
      backdrop: 'static',
      keyboard: false
    })
    modalInstance.result.then(result =>
      result === 'import'
        ? this.$state.go('import')
        : this.$state.go('risks')
    )
  }
}
