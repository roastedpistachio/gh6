import template from './riskHeader.html';
import controller from './riskHeader.controller';
import './riskHeader.scss';

let riskHeaderComponent = {
  restrict: 'E',
  bindings: {
    filterChanged: '&',
    activeRiskFilter: '<',
    searchChanged: '&'
  },
  template,
  controller
};

export default riskHeaderComponent;
