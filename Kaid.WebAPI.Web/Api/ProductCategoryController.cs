using AutoMapper;
using Kaid.WebAPI.Model.Models;
using Kaid.WebAPI.Service;
using Kaid.WebAPI.Web.Infrastructure.Core;
using Kaid.WebAPI.Web.Infrastructure.Extentions;
using Kaid.WebAPI.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace Kaid.WebAPI.Web.Api
{
    [RoutePrefix("api/productCategory")]
    [Authorize]
    public class ProductCategoryController : ApiControllerBase
    {
        #region Initialize
        public IProductCategoryService _productCategoryService;

        public ProductCategoryController(IErrorService errorService,
                                         IProductCategoryService productCategoryService)
            : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }
        #endregion
        [Route("getall")]
        [HttpGet]
       
        public HttpResponseMessage GetAll(HttpRequestMessage requestMessage,string keyword , int page, int pageSize=20)
        {
            return CreateHttpResponse(requestMessage,
                                      () =>
                                      {
                                          var model = _productCategoryService.GetAll(keyword);

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

        [Route("getallparents")]
        [HttpGet]
        
        public HttpResponseMessage GetAll(HttpRequestMessage requestMessage)
        {
            return CreateHttpResponse(requestMessage,
                                      () =>
                                      {
                                          var model = _productCategoryService.GetAll();

                                          var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);

                                          return requestMessage.CreateResponse(HttpStatusCode.OK, responseData);
                                      });
        }

        [Route("getbyid")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage requestMessage,int id)
        {
            return CreateHttpResponse(requestMessage,
                                      () => 
                                      {
                                          var model = _productCategoryService.GetById(id);

                                          var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(model);

                                          return requestMessage.CreateResponse(HttpStatusCode.OK, responseData);
                                      }
                                       );
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage requestMessage,ProductCategoryViewModel viewModel)
        {
            return CreateHttpResponse(requestMessage,
                                      ()=>
                                      {
                                          if (!ModelState.IsValid)
                                          {
                                              return requestMessage.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                                          }
                                          else
                                          {
                                              var model = new ProductCategory();
                                              model.UpdateProductCategory(viewModel);
                                              model.CreateDate = DateTime.Now;
                                              model.CreateBy = User.Identity.Name;

                                              model = _productCategoryService.Add(model);
                                              _productCategoryService.SaveChanges();

                                              var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(model);

                                              return requestMessage.CreateResponse(HttpStatusCode.Created, responseData);

                                          }

                                      });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update (HttpRequestMessage requestMessage,ProductCategoryViewModel viewModel)
        {
            return CreateHttpResponse(requestMessage,
                                       () => 
                                       {
                                           if (!ModelState.IsValid)
                                           {
                                               return requestMessage.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                                           }
                                           else
                                           {
                                               var model = new ProductCategory();
                                               model.UpdateProductCategory(viewModel);
                                               model.UpdateDate = DateTime.Now;
                                               model.UpdateBy = User.Identity.Name;
                                               _productCategoryService.Update(model);
                                               _productCategoryService.SaveChanges();

                                               var responseData = viewModel;

                                               return requestMessage.CreateResponse(HttpStatusCode.Created, responseData);
                                           }
                                       }
                                      
                                      );
        }

        [Route("remove")]
        [HttpDelete]
        public HttpResponseMessage Remove(HttpRequestMessage requestMessage, int id)
        {
            return CreateHttpResponse(requestMessage,
                                       () =>
                                       {
                                           if (!ModelState.IsValid)
                                           {
                                               return requestMessage.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                                           }
                                           else
                                           {
                                               var model =  _productCategoryService.Delete(id);
                                               _productCategoryService.SaveChanges();

                                               var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(model);

                                               return requestMessage.CreateResponse(HttpStatusCode.OK, responseData);
                                           }
                                       }

                                      );
        }

        [Route("removes")]
        [HttpDelete]
        public HttpResponseMessage MultiRemove(HttpRequestMessage requestMessage, string listIds)
        {
            return CreateHttpResponse(requestMessage,
                                       () =>
                                       {
                                           if (!ModelState.IsValid)
                                           {
                                               return requestMessage.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                                           }
                                           else
                                           {
                                               var ids = new JavaScriptSerializer().Deserialize<List<int>>(listIds);

                                               var models = new List<ProductCategory>();

                                               foreach( var id in ids)
                                               {
                                                   models.Add( _productCategoryService.Delete(id));
                                               }
                                               
                                               _productCategoryService.SaveChanges();

                                               var responseData = Mapper.Map<IEnumerable<ProductCategory>,IEnumerable< ProductCategoryViewModel>>(models);

                                               return requestMessage.CreateResponse(HttpStatusCode.OK, responseData);
                                           }
                                       }

                                      );
        }

    }
}