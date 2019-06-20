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

        function editProduct() {
            $scope.product.MoreImages = JSON.stringify($scope.moreImages);

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
                    $scope.moreImages = JSON.parse($scope.product.MoreImages);
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