export default class Risks {
  constructor($http) {
    'ngInject';
    this.$http = $http;
  }
  getAll() {
    return this.$http.get('http://gh6services.azurewebsites.net/risk').then(res => {
      res.data = res.data.map(risk => {
        risk.client.name = risk.client.name.trim().replace(/ {2,}/g, ' ')
        return risk
      })
      return res
    })
  }
  getOne(id) {
    return this.$http.get(`http://gh6services.azurewebsites.net/risk/${id}`).then(res => {
      res.data.client.name = res.data.client.name.trim().replace(/ {2,}/g, ' ')
      return res
    })
  }
  update(risk) {
    return this.$http.put(`http://gh6services.azurewebsites.net/risk/${risk.id}`, risk)
  }
  create(risk) {
    return this.$http.post('http://gh6services.azurewebsites.net/risk', risk)
  }
}
