
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Kaid.WebAPI.Model.Models;
using Kaid.WebAPI.Service;
using Kaid.WebAPI.Web.Infrastructure.Core;
using Kaid.WebAPI.Web.Models.ViewModels;

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
        public HttpResponseMessage GetAll(HttpRequestMessage requestMessage)
        {

            return CreateHttpResponse(requestMessage,
                                      () =>
                                      {
                                          var products = _productCategoryService.GetAll();
                                          var productVms = Mapper.Map<IEnumerable<ProductCategory>,IEnumerable<ProductCategoryViewModel>>(products);
                                          return requestMessage.CreateResponse(HttpStatusCode.OK, productVms);
                                      });
        }
    }
}
