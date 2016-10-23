import angular from 'angular'
import Risks from './risks'
import moment from 'moment';
import FileImports from './fileImports'
import LandlordSubmissions from './landlordSubmissions'
import Clients from './clients'

export default angular.module('app.providers', [])

.service('Risks', Risks)
.service('FileImports', FileImports)
.service('LandlordSubmissions', LandlordSubmissions)
.service('Clients', Clients)

.name


const risks = [
  {
    id: 1,
    client: {
      name: 'David Weedon',
      yearOfBirth: '1988',
      address: {
        address: '205 Bayhill Blvd.',
        city: 'Glen Carbon',
        state: 'IL'
      }
    },
    created: moment().subtract(2, 'd').toDate(),
    risk: 10,
    riskFactor: 'Eviction Notice Served',
    caseWorker: 'Cody Nutt',
    caseStatus: 'Awaiting Initial Contact',
    caseOverview: 'David was out of work, but has a new job lined up. He is going to start getting paid again in 3 weeks. He hasn’t been making rent payments though so he his landlord is trying to have him evicted.',
    intialContact: {
      contacted: false,
      informationObtained: false,
      helpRequired: false
    },
    mitigation: {},
    followUp: {},
    notes: [
      {
        date: moment().subtract(2, 'd').toDate(),
        author: 'Cody Nutt',
        message: 'Got his phone number from landlord, but no response, going to visit in-person.'
      },
      {
        date: moment().subtract(2, 'd').toDate(),
        author: 'Cody Nutt',
        message: 'Got his phone number from landlord, but no response, going to visit in-person.'
      }
    ]
  },
  {
    id: 2,
    client: {
      name: 'David Weedon',
      phone: '618-540-9161',
      address: {
        address: '205 Bayhill Blvd.',
        city: 'Glen Carbon',
        state: 'IL'
      }
    },
    created: moment().subtract(3, 'd').toDate(),
    risk: 5,
    riskFactor: 'Eviction Threatened',
    caseWorker: 'Cody Nutt',
    caseStatus: 'Mitigating',
    caseOverview: 'David was out of work, but has a new job lined up. He is going to start getting paid again in 3 weeks. He hasn’t been making rent payments though so he his landlord is trying to have him evicted.',
    intialContact: {
      contacted: true,
      informationObtained: true,
      helpRequired: false
    },
    mitigation: {
      strategy: 'One-time Financial Assistance',
      details: 'Paid off his rent ($600)',
      housingRetained: true
    },
    followUp: {
      reccomendedDate: new Date(),
      actualDate: null,
      housingRetained: true,
      clientSubjectiveStatus: 7,
      caseWorkerSubjectiveStatus: 8
    },
    notes: [
      {
        date: moment().subtract(2, 'd').toDate(),
        author: 'Cody Nutt',
        message: 'Got his phone number from landlord, but no response, going to visit in-person.'
      },
      {
        date: moment().subtract(2, 'd').toDate(),
        author: 'Cody Nutt',
        message: 'Got his phone number from landlord, but no response, going to visit in-person.'
      }
    ]
  },
  {
    id: 3,
    client: {
      name: 'Robert Hanks',
    //  yearOfBirth: '1953'
    },
    created: moment().subtract(4, 'h').toDate(),
    risk: 9,
    riskFactor: 'Eviction Threatened',
    caseStatus: 'Assignment',
    intialContact: {},
    mitigation: {},
    followUp: {},
    notes: []
  }
]
