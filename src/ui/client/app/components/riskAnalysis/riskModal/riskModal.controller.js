import template from './riskModal.html'

class ModalController {
  constructor($uibModalInstance, risk, Risks) {
    'ngInject';
    this.risk = risk
    this.modalInstance = $uibModalInstance
    this.Risks = Risks
    switch (this.risk.caseStatus) {
      case 'Awaiting Follow Up':
        this.followUpOpen = true
        break
      case 'Mitigating':
        this.mitigatingOpen = true
        break
      case 'Contacting':
        this.contactOpen = true
        break
    }
  }
  addNote() {
    this.risk.notes.push({
      message: this.newNote,
      author: 'Cody Nutt',
      date: new Date()
    });
    this.Risks.update(this.risk).then(() => {
      this.newNote = null
    }).catch(err => {
      this.risk.notes.pop()
    });
  }
  close() {
    this.modalInstance.close()
  }
  save() {
    this.Risks.update(this.risk).then(() => this.modalInstance.close())
  }
}

export default class RiskModalController {
  constructor($uibModal, $state, Risks) {
    'ngInject';
    this.modal = $uibModal
    this.$state = $state
    this.Risks = Risks
  }
  $onInit() {
    const modalInstance = this.modal.open({
      animation: true,
      controller: ModalController,
      template: template,
      controllerAs: '$ctrl',
      backdrop: 'static',
      keyboard: false,
      resolve: {
        risk: () => angular.copy(this.risk)
      }
    })
    modalInstance.result.then(() => this.$state.go('risks'));
  }
}
