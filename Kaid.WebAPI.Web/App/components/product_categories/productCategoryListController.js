
(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope','apiService','notificationService','$ngBootbox','$filter'];

    function productCategoryListController($scope, apiService, notificationService, $ngBootbox,$filter) {

        $scope.productCategories = [];

        $scope.page = 0;
       
        $scope.getProductCategories = getProductCategories;

        $scope.keyword = '';

        $scope.search = search;

        $scope.remove = remove;

        $scope.multiRemove = multiRemove;

        $scope.allSelect = allSelect;

        $scope.isAll = false;
        function allSelect() {
            if ($scope.isAll===false) {
                angular.forEach($scope.productCategories,
                               function (item) {
                                   item.checked = true;
                               });
                $scope.isAll = true;
            }else{
                angular.forEach($scope.productCategories,
                               function (item) {
                                   item.checked = false;
                               });
                $scope.isAll = false;
            }
        };

        function multiRemove() {
            var listIds = [];
            $.each($scope.selected, function (i, item) {
                listIds.push(item.ID);
            });

            var config = {
                params: {
                    listIds: JSON.stringify(listIds)
                }
            };
            apiService.remove("/api/productcategory/Removes",
                             config,
                             function(result){
                                 notificationService.displaySuccess('Deleting is success ' + result.data.length + ' records!');
                                 search();
                             },
                             function(error){
                                 notificationService.displayError('Deleting is not success!');
                             });
        }
 
        $scope.$watch("productCategories",
                      function(newer,older){
                          var checked = $filter("filter")(newer, { checked: true });

                          if (checked.length) {
                              $scope.selected = checked;
                              $('#btnRemove').removeAttr('disabled');
                          } else {
                              $('#btnRemove').attr('disabled', 'disabled');
                          }
                      },
                      true  );

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
                    pageSize: 4
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