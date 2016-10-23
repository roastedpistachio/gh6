import template from './headerLink.html';
import './headerLink.scss';

let headerLinkComponent = {
  restrict: 'E',
  bindings: {
    to: '@'
  },
  template,
  transclude: true
};

export default headerLinkComponent;
