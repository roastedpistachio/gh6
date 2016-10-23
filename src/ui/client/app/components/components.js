import angular from 'angular';
import MainHead from './mainHead/mainHead';
import Home from './home/home';
import FileImport from './fileImport/fileImport';
import RiskAnalysis from './riskAnalysis/riskAnalysis';
import LandlordSubmission from './landlordSubmission/landlordSubmission';

let componentModule = angular.module('app.components', [
  MainHead,
  Home,
  RiskAnalysis,
  FileImport,
  LandlordSubmission
])

.name;

export default componentModule;
