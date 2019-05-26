using AutoMapper;
using Kaid.WebAPI.Model.Models;
using Kaid.WebAPI.Service;
using Kaid.WebAPI.Web.Infrastructure.Core;
using Kaid.WebAPI.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kaid.WebAPI.Web.Api
{
    [RoutePrefix("api/productCategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        public IProductCategoryService _productCategoryService;

        public ProductCategoryController(IErrorService errorService,
                                         IProductCategoryService productCategoryService)
            : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage requestMessage, int page, int pageSize)
        {
            return CreateHttpResponse(requestMessage,
                                      () =>
                                      {
                                          var model = _productCategoryService.GetAll();

                                          var totalRow = model.Count();

                                          var query = model.OrderByDescending(k => k.CreateDate)
                                                           .Skip(page * pageSize)
                                                           .Take(pageSize);
                                          var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(query);

                                          PaginationSet<ProductCategoryViewModel> paginationSet = new PaginationSet<ProductCategoryViewModel>()
                                          {
                                              Items = responseData,
                                              Page = page,
                                              TotalPages = (int)Math.Ceiling((decimal)(totalRow / pageSize)),
                                              TotalCount = totalRow
                                          };
                                          return requestMessage.CreateResponse(HttpStatusCode.OK, paginationSet);
                                      });
        }
    }
}