class RiskCardController {
  constructor() {
    this.statusTypes = [
      'Assignment',
      'Awaiting Initial Contact',
      'Mitigating',
      'Awaiting Follow Up'
    ]
  }
  moveLeft() {
    let prevIndex = this.statusTypes.indexOf(this.risk.caseStatus) - 1;
    prevIndex >= 0 && this.updateStatus({status: this.statusTypes[prevIndex]});
  }
  moveRight() {
    let nextIndex = this.statusTypes.indexOf(this.risk.caseStatus) + 1;
    nextIndex !== this.statusTypes.length && this.updateStatus({status: this.statusTypes[nextIndex]});
  }
  get leftButtonDisabled() {
    return this.risk.caseStatus === this.statusTypes[0];
  }
  get rightButtonDisabled() {
    return this.risk.caseStatus === this.statusTypes[this.statusTypes.length - 1];
  }
  get riskCardClass() {
    if (this.risk.risk > 6 ) {
      return 'danger';
    } else if (this.risk.risk > 4 ) {
      return 'warning';
    }
    return 'success';
  }
}

export default RiskCardController;
