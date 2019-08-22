/*
(function () {
    var app = angular.module('app');

    var controllerId = 'sts.views.task.list';
    app.controller(controllerId, [
        '$scope', 'abp.services.app.contract',
        function ($scope, taskService) {
            var vm = this;

            vm.localize = abp.localization.getSource('SAIC_FTS');

            vm.tasks = [];

            $scope.selectedTaskState = 0;

            $scope.$watch('selectedTaskState', function (value) {
                vm.refreshTasks();
            });

            vm.refreshTasks = function () {
                abp.ui.setBusy( //Set whole page busy until getTasks complete
                    null,
                    taskService.getContracts({ //Call application service method directly from javascript
                        state: $scope.selectedTaskState > 0 ? $scope.selectedTaskState : null
                    }).then(function (data) {
                        vm.tasks = data.data.tasks;
                    })
                );
            };

            vm.changeTaskState = function (task) {
                var newState;
                if (task.state == 1) {
                    newState = 2; //Completed
                } else {
                    newState = 1; //Active
                }

                taskService.updateTask({
                    taskId: task.id,
                    state: newState
                }).then(function () {
                    task.state = newState;
                    abp.notify.info(vm.localize('TaskUpdatedMessage'));
                });
            };

            vm.getTaskCountText = function () {
                return abp.utils.formatString(vm.localize('Xtasks'), vm.tasks.length);
            };
        }
    ]);
})();


*/

(function () {
    angular.module('app').controller('app.views.test', [
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


/*
(function () {
    angular.module('app').controller('app.views.users.index', [
        '$scope', '$timeout', '$uibModal', 'abp.services.app.user',
        function ($scope, $timeout, $uibModal, userService) {
            var vm = this;

            vm.users = [];

            function getUsers() {
                userService.getAll({}).then(function (result) {
                    vm.users = result.data.items;
                });
            }

            vm.openUserCreationModal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/search/search.cshtml',
                    controller: 'app.views.layout.search as vm',
                    //templateUrl: '/App/Main/views/users/createModal.cshtml',
                    //controller: 'app.views.users.createModal as vm',
                    backdrop: 'static'
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getUsers();
                });
            };
            
            vm.openUserEditModal = function (user) {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/users/editModal.cshtml',
                    controller: 'app.views.users.editModal as vm',
                    backdrop: 'static',
                    resolve: {
                        id: function () {
                            return user.id;
                        }
                    }
                });
            
                modalInstance.rendered.then(function () {
                    $timeout(function () {
                        $.AdminBSB.input.activate();
                    }, 0);
                });

                modalInstance.result.then(function () {
                    getUsers();
                });
            };

            vm.delete = function (user) {
                abp.message.confirm(
                    "Delete user '" + user.userName + "'?",
                    function (result) {
                        if (result) {
                            userService.delete({ id: user.id })
                                .then(function () {
                                    abp.notify.info("Deleted user: " + user.userName);
                                    getUsers();
                                });
                        }
                    });
            }

            vm.refresh = function () {
                getUsers();
            };

            getUsers();
        }
    ]);
})();
*/