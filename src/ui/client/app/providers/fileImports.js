export default class FileImports {
  constructor($http, $q) {
    'ngInject';
    this.$http = $http;
    this.$q = $q;
  }
  submitFile(file) {
    var formData = new FormData();
    formData.append("file", file);

    let ret = this.$q.defer();

    this.$http.post('http://gh6services.azurewebsites.net/risk/upload', formData, {
      headers: {'Content-Type': undefined }
    }).then((data) => {
        console.log(data);
        ret.resolve(data);
    }, (er) =>{
      console.log(er);
    });

    return ret.promise;
  }

  submitMappings(data) {

    let ret = this.$q.defer();

    this.$http.post('http://gh6services.azurewebsites.net/risk/import', data).then((data) => {
        console.log(data);
        ret.resolve(data);
    }, (er) =>{
      console.log(er);
    });

    return ret.promise;
  }
}
