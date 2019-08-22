(function () {
    angular.module('app').controller('app.views.data', [
        '$scope', 'abp.services.app.contract',
        function ($scope, contractService,) {
            var vm = this;

            $scope.title;
            $scope.contractNumer;
            $scope.crn;
            $scope.startDate;
            $scope.endDate;
            $scope.commonName;
            $scope.contractStatus;
            $scope.ceilingCost;
            $scope.ceilingFee;
            $scope.ceilingValue;
            $scope.projectControlAnalyist;
            $scope.representative;
            $scope.laborCertificationRequired;
            $scope.oneLaborCategoryPerPerson;
            $scope.laborCertificationResume;
            $scope.orgID;
            $scope.programManager;
            $scope.customer;
            $scope.contractType;
            $scope.exportControlLicense;
            $scope.contractRecTypeCode;
            $scope.isKeyPersonnel;
            $scope.billingFrequency;
            
            $scope.fileExtension = "";

            //$scope.file;
            //$scope.filename = $scope.file.name;

            vm.contract = {
                title: $scope.title,
                contractNumber: $scope.contractNumer,
                crn: $scope.crn,
                startDate: $scope.startDate,
                endDate: $scope.endDate,
                commonName: $scope.commonName,
                contractStatus: $scope.contractStatus,
                ceilingCost: $scope.ceilingCost,
                ceilingFee: $scope.ceilingFee,
                ceilingValue: $scope.ceilingValue,
                projectControlAnalyist: $scope.projectControlAnalyist,
                representative: $scope.representative,
                laborCertificationRequired: $scope.laborCertificationRequired,
                oneLaborPerCategoryPerPerson: $scope.oneLaborCategoryPerPerson,
                laborCertificationResume: $scope.laborCertificationResume,
                ordID: $scope.orgID,
                programManager: $scope.programManager,
                customer: $scope.customer,
                contractType: $scope.contractType,
                exportCOntrolLicense: $scope.exportControlLicense,
                contractRecTypeCode: $scope.contractRecTypeCode,
                isKeyPersonnel: $scope.isKeyPersonnel,
                billingFrequency: $scope.billingFrequency,
                contract: $scope.fileExtension//"Tennessee Technological University: Test Upload of a Contract."
            };


            vm.saveContract = function () {
                abp.ui.setBusy(
                    null,
                    contractService.createContract(
                        //vm.contract


                        {
                            title: $scope.title,
                            contractNumber: $scope.contractNumer,
                            crn: $scope.crn,
                            startDate: $scope.startDate,
                            endDate: $scope.endDate,
                            commonName: $scope.commonName,
                            contractStatus: $scope.contractStatus,
                            ceilingCost: $scope.ceilingCost,
                            ceilingFee: $scope.ceilingFee,
                            ceilingValue: $scope.ceilingValue,
                            projectControlAnalyst: $scope.projectControlAnalyst,
                            representative: $scope.representative,
                            laborCertificationRequired: $scope.laborCertificationRequired,
                            oneLaborPerCategoryPerPerson: $scope.oneLaborCategoryPerPerson,
                            laborCertificationResume: $scope.laborCertificationResume,
                            orgID: $scope.orgID,
                            programManager: $scope.programManager,
                            customer: $scope.customer,
                            contractType: $scope.contractType,
                            exportCOntrolLicense: $scope.exportControlLicense,
                            contractRecTypeCode: $scope.contractRecTypeCode,
                            isKeyPersonnel: $scope.isKeyPersonnel,
                            billingFrequency: $scope.billingFrequency,
                            contract: $scope.fileExtension//"Tennessee Technological University: Test Upload of a Contract."
                        }


                    ).success(function () {
                        //abp.notify.info(abp.utils.formatString(localize("TaskCreatedMessage"), vm.task.description));
                        //$location.path('/');
                    })
                );
            };


            function uploadContract() {
                contractService.createContract(
                    //vm.contract


                    {
                        title: $scope.title,
                        contractNumber: $scope.contractNumer,
                        crn: $scope.crn,
                        startDate: $scope.startDate,
                        endDate: $scope.endDate,
                        commonName: $scope.commonName,
                        contractStatus: $scope.contractStatus,
                        ceilingCost: $scope.ceilingCost,
                        ceilingFee: $scope.ceilingFee,
                        ceilingValue: $scope.ceilingValue,
                        projectControlAnalyst: $scope.projectControlAnalyst,
                        representative: $scope.representative,
                        laborCertificationRequired: $scope.laborCertificationRequired,
                        oneLaborPerCategoryPerPerson: $scope.oneLaborCategoryPerPerson,
                        laborCertificationResume: $scope.laborCertificationResume,
                        orgID: $scope.orgID,
                        programManager: $scope.programManager,
                        customer: $scope.customer,
                        contractType: $scope.contractType,
                        exportCOntrolLicense: $scope.exportControlLicense,
                        contractRecTypeCode: $scope.contractRecTypeCode,
                        isKeyPersonnel: $scope.isKeyPersonnel,
                        billingFrequency: $scope.billingFrequency,
                        contract: $scope.fileExtension//"Tennessee Technological University: Test Upload of a Contract."
                    }
                ).success(function () {
                    //abp.notify.info("Testing");
                    //abp.notify.info(abp.utils.formatString(localize("TaskCreatedMessage"), vm.task.description));
                    //$location.path('/');
                })
            };

            function testFunction() { };

            $scope.add = function () {


                var newPerson = {
                    CompanyName: 'Dougles Adams',
                    ID: 42
                };

                /*
                abp.ajax({
                    url: '/Test/SavePerson',
                    data: JSON.stringify(newPerson)
                }).done(function (data) {
                    abp.notify.success('Created new person with id = ' + data.personId);
                });
*/

                var f = document.getElementById('file').files[0],
                    r = new FileReader();

                r.onloadend = function (e) {
                    
//                    var data = e.target.result;
                    var extn = f.name.split(".").pop();
                    $scope.fileExtension = extn;
                    //$scope.fileExtension = extn;
                    //var thefile = e.target.result;
                    //send your binary data via $http or $resource or do anything else with it
//                    contractService.testUpload(data, extn);
//                    vm.saveContract()
                    

                    var thefile = e.target.result;


                var newFile = {                
                    FileBinary: thefile,        
                    Extension: extn
                };

                abp.ajax({
                    url: '/Test/SavePerson',
                    data: JSON.stringify(newFile)
                }).done(function (data) {

                    //vm.saveContract();
                    uploadContract();
                    //testFunction();                    
                        });
                    abp.notify.success("Uploaded a Contract from " + $scope.fileExtension + "-type file");

                }

                abp.notify.success("Uploading...");
                r.readAsDataURL(f);
                //r.readAsArrayBuffer(f);
                //r.readAsBinaryString(f);
            }
        }
    ]);
})();