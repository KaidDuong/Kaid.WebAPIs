
(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope','apiService','notificationService','$ngBootbox'];

    function productCategoryListController($scope, apiService, notificationService, $ngBootbox) {

        $scope.productCategories = [];
        $scope.page = 0;
        //$scope.pagesCount = 0;
        $scope.getProductCategories = getProductCategories;
        $scope.keyword = '';

        $scope.search = search;

        $scope.remove = remove;

        function remove(id) {
            $ngBootbox.confirm('Are you sure to delete its?')
          .then(
                function () {
                    var config = {
                        params: {
                            id: id
                        }
                    };

                    apiService.remove("/api/productcategory/remove",
                                      config,
                                      function(){
                                          notificationService.displaySuccess('Deleting is success!');
                                          search();
                                      },
                                      function(){
                                          notificationService.displayError('Deleting is not success!');
                                      });

                });
        };

        function search () {
            getProductCategories()
        };
        
        function getProductCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 2
                }
            }
            apiService.get("/api/productcategory/getall",
                            config,
                            function (result)
                            {
                                if (result.data.TotalCount == 0) {
                                    notificationService.displayWarning('There are no the records was found!');
                                }
                                else if(config.params.keyword !=''){
                                    notificationService.displaySuccess('Find ' + result.data.TotalCount + ' record(s)');
                                }
                                $scope.productCategories = result.data.Items;
                                $scope.page = result.data.Page;
                                $scope.pagesCount = result.data.TotalPages;
                                $scope.totalCount = result.data.TotalCount;
                             },
                            function ()
                            {
                                console.log('Load product categories failed.');
                            }
                          );
        }
         $scope.getProductCategories();
    }
})(angular.module('kaid.product_categories'));