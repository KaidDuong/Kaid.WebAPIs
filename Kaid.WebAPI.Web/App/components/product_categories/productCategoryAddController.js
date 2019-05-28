(function (app) {
    app.controller('productCategoryAddController', productCategoryAddController);

    productCategoryAddController.$inject = ['apiService','$scope','notificationService','$state','commonService'];
    function productCategoryAddController(apiService, $scope, notificationService,$state,commonService)
    {
        $scope.productCategory =
            {
            CreateDate: new Date(),
            Status: true,
            HomeFlag: true
            };

        $scope.getSeoTitle = getSeoTitle;

        $scope.addProductCategory = addProductCategory;

        function getSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }

        function addProductCategory() {
            apiService.post('/api/productcategory/create',
                $scope.productCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + 'is created !');
                    $state.go('product_categories');
                },
                function () {
                    notificationService.displayError('Creating is not success!');
                });
        }

        function loadParentCategories() {
            apiService.get('/api/productcategory/getallparents',
                           null,
                           function (result) 
                           {
                               $scope.parentCategories = result.data;
                           },
                           function ()
                           {
                               console.log('Can not get list of the parent Categories!');
                           });
        }

        loadParentCategories();
    }
})(angular.module('kaid.product_categories'));