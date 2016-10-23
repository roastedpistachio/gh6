
class FileImportController {

  constructor(FileImports, $scope) {
     'ngInject';

    this.name = 'fileImport';    
    this.$scp = $scope;
    this.fileImports = FileImports;
    this.paneNum = 1;
    this.selectedPane = 'pane1';
    this.selections = [];
  }

  submitFile() {

    return this.fileImports.submitFile(this.$scp.file).then((results) => {

      results.data.serverNames = [
    "First Name",
    "Last Name",
    "Address",
    "City",
    "State",
    "Details"
  ];
    this.fileName = results.data.FileName;
    results.data.headers = results.data.Headers;
    results.data.data = results.data.Data;

      this.selections.splice(0, this.selections.length);
      for(let i = 0; i < results.data.serverNames.length; i++) {
        
        this.selections.push({
          serverName: results.data.serverNames[i],
          index: i,
          selectedColumnText: "Please select a field",
          selectedColumnSubtext: "",
          selectedColumnIndex: -1
        })
      }

      this.data = results.data;
    
    });
  }

selectField(serverIndex, columnIndex, columnText, columnSubText) {
  this.selections[serverIndex].selectedColumnText = columnText;
    this.selections[serverIndex].selectedColumnSubtext = columnSubText;
  this.selections[serverIndex].selectedColumnIndex = columnIndex;
}

startOver() {
    this.paneNum = 1;
    this.selectedPane = 'pane1';
}

  prevPane() {
    this.paneNum--;
    this.selectedPane = 'pane' + this.paneNum.toString();
  }

  nextPane() {
    var self = this;
    if (this.paneNum === 1) {
      this.submitFile().then(() => {
        self.paneNum++;
        self.selectedPane = 'pane' + this.paneNum.toString();
      });
    } else {

       if (this.paneNum === 3) {

          let final = {fileName: this.fileName, mappings: [], riskType: this.data.riskType };
          for(var i = 0; i < this.selections.length; i++) {
              if (this.selections[i].selectedColumnIndex > -1) {
              final.mappings.push({
                  key: this.selections[i].serverName.split(' ').join(''),
                  value: this.selections[i].selectedColumnIndex
              });          
              }
          }

          this.fileImports.submitMappings(final).then(() => {

          });
   self.paneNum++;
      self.selectedPane = 'pane' + this.paneNum.toString();
       }else {
      self.paneNum++;
      self.selectedPane = 'pane' + this.paneNum.toString();
       }
    }

  }
}

export default FileImportController;
 