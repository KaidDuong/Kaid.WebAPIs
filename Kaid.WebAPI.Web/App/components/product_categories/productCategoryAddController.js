(function (app) {
    app.controller('productCategoryAddController', productCategoryAddController);

    productCategoryAddController.$inject = ['apiService','$scope','notificationService','$state'];
    function productCategoryAddController(apiService, $scope, notificationService,$state)
    {
        $scope.productCategory =
            {
            CreateDate: new Date(),
            Status: true,
            HomeFlag: true
            };

        $scope.addProductCategory = addProductCategory;

        function addProductCategory() {
            apiService.post('api/productcategory/create',
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
            apiService.get('api/productcategory/getallparents',
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