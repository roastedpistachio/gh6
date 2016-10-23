import template from './riskCard.html';
import controller from './riskCard.controller';
import './riskCard.scss';

let riskCardComponent = {
  restrict: 'E',
  bindings: {
    risk: '<',
    updateStatus: '&'
  },
  template,
  controller
};

export default riskCardComponent;
