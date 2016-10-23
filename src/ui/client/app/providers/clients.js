export default class Risks {
  constructor($http) {
    'ngInject';
    this.$http = $http;
  }

  query(risk) {
    return this.$http.get('http://gh6services.azurewebsites.net/client/search', {params: {
      name: risk.client.name,
      yearOfBirth: risk.client.yearOfBirth,
      address: risk.client.address,
      city: risk.client.city,
      state: risk.client.state
    }});
  }
}
