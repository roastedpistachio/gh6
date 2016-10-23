class LandlordSubmissionController {
  constructor(LandlordSubmissions) {
     'ngInject';

    this.name = 'landlordSubmission';
    this.submission = LandlordSubmissions;
    this.data = {};
  }
 
  submit(e) {

    this.submission.submit(this.data).then(() => {

    });

    e.preventDefault();
    this.submitted = true; //Move into result once it works

    return false
  }

  startOver() {
    this.submitted = false;
    this.data = {};

  }
}

export default LandlordSubmissionController;
