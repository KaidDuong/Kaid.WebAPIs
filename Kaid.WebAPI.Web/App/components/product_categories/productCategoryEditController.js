(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);

    productCategoryEditController.$inject = ['apiService', '$scope', 'notificationService','$state','$stateParams','commonService'];

    function productCategoryEditController(apiService, $scope, notificationService,$state,$stateParams,commonService) {
        $scope.productCategory = {
            UpdateDate: new Date()
        };

        $scope.getSeoTitle = getSeoTitle;

        $scope.editProductCategory = editProductCategory;

        $scope.loadProductCategoryDetail = loadProductCategoryDetail;

        $scope.loadParentCategory = loadParentCategory;

        function getSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }

        function editProductCategory() {
            apiService.put('/api/productcategory/update',
                $scope.productCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' is updated!');
                    $state.go('product_categories');
                }, function () {
                    notificationService.displayError('Updating is not success!!');
                });
        }

        function loadProductCategoryDetail() {
            var config = {
                params: {
                    id: $stateParams.id
                }
            };
            apiService.get('/api/productcategory/getbyid' ,
                config,
                function (result) {
                    $scope.productCategory = result.data;
                },
                function (error) {
                    notificationService.displayError(error.data.Message);
                }
            );
        }

        function loadParentCategory() {
            apiService.get('/api/productcategory/getallparents',
                null,
                function (result) {
                    $scope.parentCategories = result.data;
                },
                function () {
                    console.log('Cannot load the list of the parent categories!');
                }
            );
        }
        loadParentCategory();
        loadProductCategoryDetail();
    }
})(angular.module('kaid.product_categories'));