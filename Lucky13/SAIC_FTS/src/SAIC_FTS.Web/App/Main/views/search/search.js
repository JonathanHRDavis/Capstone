(function () {
    angular.module('app').controller('app.views.layout.search', [
        '$scope', '$timeout', '$uibModal', 'abp.services.app.contract',
        function ($scope, $timeout, $uibModal, contractService) {
            var vm = this;
            $scope.sortContractsBy = 'Title';
            $scope.sortReverse = false;
            $scope.text = false;
            $scope.searchKey = "";

            $scope.contractNumber = 1;
            $scope.contractText = "";
            $scope.contractTitle = "";

            vm.contracts = [];


            function get_contracts() {
                contractService.getContracts({}).then(function (result) {
                    vm.contracts = result.data.contracts;
                });
            }

            function basic_search() {
                contractService.fullTextSearch($scope.searchKey).then(function (result) {
                    vm.contracts = result.data.contracts;
                });
            }

            $scope.deltaImport = function() {
                contractService.deltaImport();
            }

            $scope.solrSearch = function () {
                if ($scope.searchKey == "") {
                    vm.refresh();
                } else {
                    contractService.fullTextSearch($scope.searchKey).then(function (result) {
                        vm.contracts = result.data.contracts;
                    });
                }
            };

            $scope.getContractText = function (contract) {
                $scope.contractNumber = contract.fullContractNum;

                var uibModalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/contractText/contractText.cshtml',
                    controller: 'app.views.contractText as vm',
                    backdrop: 'true',
                    resolve: {
                        number: function () {
                            return $scope.contractNumber;
                        },
                        title: function () {
                            return $scope.contractTitle;
                        }
                    },
                });
            };

            $scope.setTitle = function (title) {
                $scope.contractTitle = title;
            }
            /*          
                        vm.opencontractCreationModal = function () {
                            var modalInstance = $uibModal.open({
                                templateUrl: '/App/Main/views/search/search.cshtml',
                                controller: 'app.views.layout.search as vm',
                                //templateUrl: '/App/Main/views/contracts/createModal.cshtml',
                                //controller: 'app.views.contracts.createModal as vm',
                                backdrop: 'static'
                            });
            
                            modalInstance.rendered.then(function () {
                                $.AdminBSB.input.activate();
                            });
            
                            modalInstance.result.then(function () {
                                getcontracts();
                            });
                        };
            */
            /*
            vm.opencontractEditModal = function (contract) {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/contracts/editModal.cshtml',
                    controller: 'app.views.contracts.editModal as vm',
                    backdrop: 'static',
                    resolve: {
                        id: function () {
                            return contract.id;
                        }
                    }
                });

                modalInstance.rendered.then(function () {
                    $timeout(function () {
                        $.AdminBSB.input.activate();
                    }, 0);
                });

                modalInstance.result.then(function () {
                    getcontracts();
                });
            };
*/

            vm.delete = function (contract) {
                abp.message.confirm(
                    "Delete contract '" + contract.title + "'?",
                    function (result) {
                        if (result) {
                            contractService.delete({ id: contract.id })
                                .then(function () {
                                    abp.notify.info("Deleted contract: " + contract.title);
                                    getcontracts();
                                });
                        }
                    });
            }

            vm.refresh = function () {
                get_contracts();
            };
        }
    ]);
})();