import template from './riskAnalysis.html';
import controller from './riskAnalysis.controller';
import './riskAnalysis.scss';

let riskAnalysisComponent = {
  restrict: 'E',
  bindings: {
    risks: '<'
  },
  template,
  controller
};

export default riskAnalysisComponent;
