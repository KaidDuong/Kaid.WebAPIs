(function (app) {
    app.controller('productAddController',
                    productAddController);

    productAddController.$inject = ['$scope','apiService','$state','commonService','notificationService'];

    function productAddController($scope, apiService, $state, commonService, notificationService) {

        $scope.product = {
            CreateDate: new Date(),
            Status: true,
            HomeFlag: true
        };

        $scope.getSeoTitle = getSeoTitle;

        $scope.addProduct = addProduct;

        $scope.ckeditorOptions = {
            language: 'vi',
            height:'200px'
        };

        function getSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function addProduct() {
            apiService.post("/api/product/create",
                            $scope.product,
                            function(result){
                                notificationService.displaySuccess(result.data.Name + ' is created!');
                                $state.go('products');
                            },
                            function(){
                                notificationService.displayError('This record is not created!');
                            }
                            );
        }

        function getProductCategory() {
            apiService.get("/api/productcategory/getallparents",
                            null,
                            function(result){
                                $scope.productCategories = result.data;
                            },
                            function(){
                                console.log('Can not get product categories!');
                            }
                            );
        }

        getProductCategory();

    }

})(angular.module('kaid.products'));