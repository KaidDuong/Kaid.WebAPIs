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

        $scope.chooseImage = function () {
            var ckFinder = new CKFinder();
            ckFinder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                });
            };
            ckFinder.popup();
        };

        $scope.moreImages = [];

        $scope.chooseMoreImages = function () {
            var ckFinder = new CKFinder();
            ckFinder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                });
            };
            ckFinder.popup();
        };

        function getSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function addProduct() {
            $scope.product.MoreImages = JSON.stringify( $scope.moreImages);

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