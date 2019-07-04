
(function (app) {
    app.controller('productListController',
                    productListController);

    productListController.$inject = ['$scope','apiService','notificationService','$ngBootbox','$filter'];

    function productListController($scope, apiService, notificationService, $ngBootbox, $filter) {

        $scope.products = [];

        $scope.page = 0;

        $scope.getProducts = getProducts;

        $scope.keyword ='';

        $scope.search = search;

        $scope.remove = remove;

        $scope.multiRemove = multiRemove;

        $scope.allSelect = allSelect;

        $scope.isAllSelect = false;

        function getProducts(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 4
                }
            };

            apiService.get("/api/product/getall",
                           config,
                           function(result){
                               if (result.data.TotalCount == 0) {
                                   notificationService.displayWarning('There are no records is found!');
                               }
                               else if (config.params.keyword != '') {
                                   notificationService.displaySuccess('Find '+result.data.TotalCount+ 'records!');
                               }

                               $scope.products = result.data.Items;
                               $scope.page = result.data.Page;
                               $scope.pagesCount = result.data.TotalPages;
                               $scope.totalCount = result.data.TotalCount;

                           },
                           function(){
                               console.log('Load products failed.');
                               notificationService.displayError('Load products failed!');
                           });
        }

        function search() {
            getProducts();
        }

        function remove(id) {
            $ngBootbox.confirm('Are you sure to delete its?')
                      .then(
                            function () {
                                var config = {
                                    params: {
                                        id: id
                                    }
                                };
                                
                                apiService.remove("/api/product/remove",
                                                  config,
                                                  function () {
                                                       notificationService.displaySuccess('Deleting Is Success!');
                                                       getProducts();
                                                    },
                                                  function () {
                                                       notificationService.displayError('Deleting is not success!');
                                                    }
                                                  ); 
                           });
        }

        function multiRemove() {
            var listIds = [];

            $.each($scope.selected,
                  function (i, item) {
                      listIds.push(item.ID);
                 });

            var config = {
                params: {
                    listIds: JSON.stringify(listIds)
                }
            };

            apiService.remove("/api/product/Removes",
                              config,
                              function(result){
                                  notificationService.displaySuccess('Deleting is success '+result.data.length+' records' );
                                  getProducts();
                              },
                              function(){
                                  notificationService.displayError('Deleting is not success!');
                              }
                             );
        }

        function allSelect() {
            if ($scope.isAllSelect === false) {
                angular.forEach($scope.products,
                    function (item) {
                        item.checked = true;
                    }
                );
                $scope.isAllSelect = true;
            }
            else {
                angular.forEach($scope.products,
                                function(item){
                                    item.checked = false;
                                }
                               );

                $scope.isAllSelect = false;
            }
        }

        $scope.$watch("products", 
                      function (newer,older) { 
                          var checked = $filter("filter")(newer, { checked: true });

                          if (checked.length) {
                              $scope.selected = checked;
                              $('#btnRemove').removeAttr('disabled');
                          }
                          else {
                              $('#btnRemove').attr('disabled', 'disabled');
                          }
                      },
                      true );

        getProducts();
    }
})(angular.module('kaid.products'));