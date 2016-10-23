export default class LandlordSubmissions {
  constructor($http, $q) {
    'ngInject';
    this.$http = $http;
    this.$q = $q;
  }

  submit(data) {

    let ret = this.$q.defer();

    data.riskType = "Landlord Warning";

    this.$http.post('http://gh6services.azurewebsites.net/risk/incoming-risk', data).then((data) => {
        console.log(data);
        ret.resolve(data);
    }, (er) =>{
      console.log(er);
    });

    return ret.promise;
  }
}
