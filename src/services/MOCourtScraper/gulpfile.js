/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp'),
      child_process = require("child_process"),
    spawn = child_process.spawn,
      path = require('path'),
      seriate = require('seriate'),
       webdriverio = require('webdriverio'),
       cheerio = require('cheerio'),
       q = require('q'),
request = require('request'),
        runner = require("./runner.js");

gulp.task('run-tests-e2e-update-selenium', function (done) {

    child_process.spawn(getProtractorBinary('webdriver-manager'), ['update'], {
        stdio: 'inherit'
    }).once('close', done);

});


gulp.task('scrape-today', ['run-tests-e2e-update-selenium'], function () {
    

    let webdriver = child_process.spawn(getProtractorBinary('webdriver-manager'), ['start'], {
        //stdio: 'inherit'
    });

    var rows = [];

    var options = { desiredCapabilities: { browserName: 'chrome' } };

    var courtId = 'CT22';
    let compiled = [];

    var browser = webdriverio.remote(options),
        recordsPerPage = 0,
        totalRecords = 0,
        totalPages = 0,
        currentPage = 0;

    var b = browser.init()
        .url("https://www.courts.mo.gov/casenet/cases/filingDateSearch.do")


        .click("#courtId")

        .selectByValue("#courtId", "CT21")
        .pause(2000);

    //b.waitUntil(() => {
    //    return b.execute("return document.readyState").then((r: any) => {
    //        console.log(r);
    //        return r.value === "complete";
    //    });
    //});

    b.click("#courtId")

        .selectByValue("#courtId", "CT22")
        .pause(2000)
        .waitUntil(() => {
            return b.execute("return document.readyState").then((r) => {
                console.log(r);
                return r.value === "complete";
            });
        })

        .execute("document.getElementById('inputVO.startDate').value = '10/16/2016';")
        .execute("var el = document.getElementById('inputVO.caseType'); var ops = el.getElementsByTagName('option'); el.options[1].selected = true;")

        .pause(2000)
        .click("#findButton")
        .waitUntil(() => {

            return b.execute("return document.readyState").then((r) => {

                return r.value === "complete";
            });
        })
        .execute("return document.querySelectorAll('.resultDescription')[0].innerHTML.replace(/(<([^>]+)>)/ig, '').replace(/\s\s+/g, ' ')")
        .then((result) => {
            let resultDescription = result.value.replace(/\s\s+/g, ' ').split('records')[0].replace('Displaying ', '').replace(' thru', '').replace(' of', '').split(' ');

            recordsPerPage = resultDescription[1];
            totalRecords = resultDescription[2];
            totalPages = Math.floor(totalRecords / recordsPerPage);

            console.log("Records per Page: " + recordsPerPage.toString());

            console.log("Records per totalRecords: " + totalRecords.toString());

            console.log("Records per totalPages: " + totalPages.toString());

            return true;
        })
        .then(() => {
            let overall = q.defer(),
                starter = q.defer(),
                perPagePromise = starter.promise;

            for (var page = 0; page < totalPages; page++) {
                perPagePromise = perPagePromise.then(() => {

                    return b.execute('var text = ""; var els = document.querySelectorAll("table table table")[9].querySelectorAll("tr"); for(var i = 0; i < els.length; i++) { text += els[i].outerHTML; } return text;').then((result) => {
                        let rows = [],
                            p = q.defer();

                        rows.push(result.value);

                        console.log("Current Page: " + currentPage);

                        for (var i = 0; i < rows.length; i++) {

                            let $ = cheerio.load(rows[i]),
                                dateFiles = [],
                                caseNumbers = [],
                                styleofCahse = [],
                                caseType = [];

                            let dateFileRows = $('tr td:nth-child(2)');

                            for (let h = 0; h < dateFileRows.length - 1; h++) {
                                dateFiles.push(dateFileRows[h].lastChild.nodeValue);
                            }

                            let caseNums = $('tr td:nth-child(3) a');

                            for (let h = 0; h < caseNums.length - 1; h++) {
                                caseNumbers.push(caseNums[h].lastChild.nodeValue.trim());
                            }

                            let styles = $('tr td:nth-child(4)');

                            for (let h = 0; h < styles.length - 1; h++) {
                                styleofCahse.push(styles[h].lastChild.nodeValue.trim());
                            }

                            let caseTypes = $('tr td:nth-child(5)');

                            for (let h = 0; h < caseTypes.length - 1; h++) {
                                caseType.push(caseTypes[h].lastChild.nodeValue.trim());
                            }

                            

                            console.log("Data Files: " + dateFiles.length);
                            console.log("Data Files: " + caseNumbers.length);
                            console.log("Data Files: " + styleofCahse.length);
                            console.log("Data Files: " + caseType.length);

                            try {
                                for (let c = 0; c < caseType.length; c++) {

                                    if (caseType[c].indexOf('Rent') > 0 || caseType[c].indexOf('Landlord') > 0) {
                                        compiled.push({
                                            date: dateFiles[c].trim(),
                                            caseNumber: caseNumbers[c].trim(),
                                            person: styleofCahse[c].trim(),
                                            caseType: caseType[c].trim()
                                        });
                                    }
                                }
                            }
                            catch (er) {
                                console.log(er);
                            }

                            console.log("Compiled: " + compiled.length);
                            if (compiled.length > 0) {


                                if (currentPage <= totalPages) {
                                    currentPage++;
                                    b.execute("goToThisPage(" + currentPage + ");").then(() => {

                                        b.pause(2000);
                                        p.resolve();
                                    });
                                } else {
                                    p.resolve();
                                }

                             
                            } else {

                                if (currentPage <= totalPages) {
                                    currentPage++;
                                    b.execute("goToThisPage(" + currentPage + ");").then(() => {

                                        b.pause(2000);
                                        p.resolve();
                                    });
                                }
                            }
                        }

                        return p.promise;

                    });

                });
            }

            starter.resolve();

            perPagePromise.then(() => {
                overall.resolve();
            });

            return overall.promise;
        }).then(() => {

            let overall = q.defer(),
                pageNavStart = q.defer(),
                pageNavPromise = pageNavStart.promise,
                additionals = [];

            for (let g = 0; g < compiled.length; g++) {
                ((function (g) {

                    pageNavPromise = pageNavPromise.then(() => {
                        let inner = q.defer(),
                            caseNum = compiled[g].caseNumber;

                        b.execute("goToThisCase('" + caseNum + "','" + courtId + "');").then(() => {
                            b.pause(1000);
                            b.execute("submitForCaseDetails('parties.do')").then(() => {
                                b.pause(1000).then(() => {

                                    b.execute("let rows3 = []; document.querySelectorAll('.detailSeperator').forEach(function (item) { if (item.innerHTML.replace(/\s\s+/g, ' ').indexOf('Defendant') > 0) { rows3.push(item.innerHTML.replace(/\s\s+/g, ' ').split('Defendant')[0]);  } }); let val = ''; for(let h = 0; h < rows3.length; h++) { val += rows3[h] + '|||' } return val; ").then((result) => {

                                        console.log(result.value);

                                        let defs = result.value || "",
                                            splitDefs = defs.split('|||');

                                        for (let r = 0; r < splitDefs.length; r++) {
                                            if (splitDefs[r] && splitDefs[r] !== '') {
                                                let name = splitDefs[r].split(','),
                                                      lastName = name.splice(0, 1)[0].replace(/\s\s+/g, ' '),
                                                      firstName = name.join(' ').replace(/\s\s+/g, ' ');

                                                if (r === 0) {
                                                    compiled[g].firstName = firstName;
                                                    compiled[g].lastName = lastName;
                                                } else {
                                                    let nw = JSON.parse(JSON.stringify(compiled[g]));
                                                    nw.firstName = firstName;
                                                    nw.lastName = lastName;
                                                    additionals.push(nw);
                                                }
                                            }
                                        }

                                        b.execute("history.go(-1)").then(() => {
                                            b.execute("history.go(-1)").then(() => {
                                                inner.resolve();
                                            });
                                        });
                                    });

                                });
                            });
                        });

                        return inner.promise;
                    });

                })(g));
            }

            pageNavStart.resolve();

            pageNavPromise.then(() => {
               
                for (let c = 0; c < additionals.length; c++) {
                    compiled.push(additionals[c]);
                }

                let ov = q.defer(),
                    insertStart = q.defer(),
                    insertProm = insertStart.promise,
                    ix = 0;

                for (var u = 0; u < compiled.length; u++) {
                 
                    insertProm = insertProm.then(() => {

                        let inp = q.defer();

                        if (ix < compiled.length) {

                            let insert = {};
                            insert.riskType = 'Housing Court Case';
                            insert.details = 'Case Number: ' + compiled[ix].caseNumber;
                            if (compiled[ix].firstName) {
                                insert.firstName = compiled[ix].firstName.replace(/\w\S*/g, function (txt) { return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase(); });
                                insert.lastName = compiled[ix].lastName.replace(/\w\S*/g, function (txt) { return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase(); });
                            } else {
                                insert.firstName = compiled[ix].person.replace(/\w\S*/g, function (txt) { return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase(); });
                            }

                            var req = request({
                                method: 'POST',
                                url: 'http://gh6services.azurewebsites.net/risk/incoming-risk',
                                headers: {
                                    'Accept': 'application/json'
                                },
                                body: insert,
                                json: true,
                                "rejectUnauthorized": false //Bad

                            }, (error, response, body) => {
                               
                                inp.resolve();
                                ix++;
                            });


                        } else {
                            inp.resolve();
                        }

                        return inp.promise;
                    });
                }

                insertStart.resolve();

                insertProm.then(() => {
                    ov.resolve();
                });

                return ov;
            }).then(() => {
                overall.resolve();
            });

            return overall.promise;
        })

    .end().then(() => {

        webdriver.kill();
    });



});


function getProtractorBinary(binaryName) {
    var winExt = /^win/.test(process.platform) ? '.cmd' : '';
    var pkgPath = require.resolve('protractor');
    var protractorDir = path.resolve(path.join(path.dirname(pkgPath), '..', '..', '.bin'));
    return path.join(protractorDir, '/' + binaryName + winExt);
}
