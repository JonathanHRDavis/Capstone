(function () {
    angular.module('app').controller('app.views.contractText', [
        '$scope', '$uibModalInstance', 'abp.services.app.contract', 'number', 'title',
        function ($scope, $uibModalInstance, contractService, number, title) {
            var vm = this;

            $scope.contractNumber = number;
            $scope.contractTitle = title;
            $scope.contractText = "";

            $scope.getContractText = function () {
                contractService.getContractText($scope.contractNumber).then(function (result) {
                    $scope.contractText = result;
                });
            };

            $scope.closeModal = function () {
                $uibModalInstance.close();
            }

            $scope.getContractText();
        }
    ]);
})();