import './assignmentModal.scss';

class AssignmentModalController {
  constructor($uibModalInstance, risk, matches, Risks) {
    'ngInject';
    this.modalInstance = $uibModalInstance;
    this.risk = risk;
    this.Risks = Risks;
    this.matches = matches;
    console.log(this.risk);
  }
  assignMatch(match) {
    this.risk.client = Object.assign({}, this.risk.client, {
      name: `${match.firstName} ${match.lastName}`,
      dateOfBirth: new Date(match.dateOfBirth),
      address: {
        address: match.address,
        city: match.city,
        state: match.state
      }
    });
    this.Risks.update(this.risk).then(() => this.save());
  }
  close() {
    this.modalInstance.dismiss();
  }
  save() {
    this.modalInstance.close();
  }
}

export default AssignmentModalController;
