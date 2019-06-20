(function (app)
{
    app.controller('productEditController',
                    productEditController);

    productEditController.$inject = ['apiService', 'notificationService', '$scope', '$state', '$stateParams', 'commonService'];

    function productEditController(apiService, notificationService, $scope, $state, $stateParams, commonService) {
        $scope.product = {};

        $scope.getSeoTitle = getSeoTitle;

        $scope.editProduct = editProduct;

        $scope.loadProductDetail = loadProductDetail;

        $scope.loadProductCategory = loadProductCategory;

        $scope.ckeditorOptions = {
            language: 'vi',
            height: '200'
        };

        $scope.chooseImage = function () {
            var ckfinder = new CKFinder();
            ckfinder.selectActionFunction = function (fileUrl) {
                $scope.product.Image = fileUrl;
            };
            ckfinder.popup();
        };

        function getSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function editProduct() {
            apiService.put('/api/product/update',
                          $scope.product,
                          function(result){
                              notificationService.displaySuccess(result.data.Name + ' is updated!');
                              $state.go('products');
                          },
                          function(){
                              notificationService.displayError('Updating is not success!');
                          }
                          );
        }

        function loadProductDetail() {
            var config = {
                params: {
                   id : $stateParams.id
                }
            };
            apiService.get('/api/product/getbyid',
                config,
                function (result) {
                    $scope.product = result.data;
                },
                function (error) {
                    notificationService.displayError(error.data.Message);
                }
            );
        }

        function loadProductCategory() {
            apiService.get('api/productcategory/getallparents',
                          null,
                          function(result){
                              $scope.productCategories = result.data;
                          },
                          function(error){
                              notificationService.displayError(error.data);
                          }
                          );
        }

        loadProductCategory();
        loadProductDetail();
    }

})(angular.module('kaid.products'));