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
    [RoutePrefix("api/product")]
    [Authorize]
    public class ProductController : ApiControllerBase
    {
        private IProductService _productService;
       
        public ProductController(IProductService productService,IErrorService errorService): base(errorService)
        {
            this._productService = productService;
        }

        [HttpGet]
        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage requestMessages,
            string keyword, int page, int pageSize=20)
        {
            return CreateHttpResponse(requestMessages, 
                                      () => {
                                          var model = _productService.GetAll(keyword);

                                          var totalRow = model.Count();

                                          var query = model.OrderByDescending(k => k.CreateDate)
                                                          .Skip(page * pageSize)
                                                          .Take(pageSize);

                                          var responseData = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(query);

                                          PaginationSet<ProductViewModel> paginationSet = new PaginationSet<ProductViewModel>()
                                          {
                                              Items = responseData,
                                              Page = page,
                                              TotalPages = (int)Math.Ceiling((decimal)(totalRow / pageSize)),
                                              TotalCount = totalRow
                                          };

                                          return requestMessages.CreateResponse(HttpStatusCode.OK, paginationSet);
                                      }
                                      );
        }

        [HttpGet]
        [Route("getbyid")]
        public HttpResponseMessage GetById(HttpRequestMessage requestMessage, int id)
        {
            return CreateHttpResponse(requestMessage,
                                      () =>
                                      {
                                          var model = _productService.GetById(id);

                                          var responseData = Mapper.Map<Product, ProductViewModel>(model);

                                          return requestMessage.CreateResponse(HttpStatusCode.OK, responseData);
                                      }
                                      );

        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(HttpRequestMessage requestMessage, ProductViewModel viewModel)
        {
            return CreateHttpResponse(requestMessage,
                                      () => {
                                          if (!ModelState.IsValid)
                                          {
                                              return requestMessage.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                                          }
                                          else
                                          {
                                              var model = new Product();

                                              model.UpdateProduct(viewModel);
                                              model.CreateDate = DateTime.Now;
                                              model.CreateBy = User.Identity.Name;

                                              model=_productService.Add(model);
                                              _productService.SaveChanges();

                                              var responseData = Mapper.Map<Product, ProductViewModel>(model);

                                              return requestMessage.CreateResponse(HttpStatusCode.Created, responseData);
                                          }
                                      });
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage requestMessage, ProductViewModel viewModel)
        {
            return CreateHttpResponse(requestMessage, 
                                      () => {
                                          if (!ModelState.IsValid)
                                          {
                                              return requestMessage.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                                          }
                                          else
                                          {
                                              var model = new Product();

                                              model.UpdateProduct(viewModel);

                                              model.UpdateDate = DateTime.Now;
                                              model.UpdateBy = User.Identity.Name;

                                              _productService.Update(model);
                                              _productService.SaveChanges();

                                              var responseData = viewModel;

                                              return requestMessage.CreateResponse(HttpStatusCode.Created, responseData);
                                          }
                                      });
        }

        [HttpDelete]
        [Route("remove")]
        public HttpResponseMessage Remove(HttpRequestMessage requestMessage, int id)
        {
            return CreateHttpResponse(requestMessage,
                                      () => {
                                          if (!ModelState.IsValid)
                                          {
                                              return requestMessage.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                                          }
                                          else{
                                              var model = _productService.Delete(id);
                                              _productService.SaveChanges();

                                              var responseData = Mapper.Map<Product, ProductViewModel>(model);

                                              return requestMessage.CreateResponse(HttpStatusCode.OK, responseData);
                                          }
                                      });
        }

        [HttpDelete]
        [Route("removes")]
        public HttpResponseMessage Removes(HttpRequestMessage requestMessage, string listIds)
        {
            return CreateHttpResponse(requestMessage, 
                                      () => {
                                          if (!ModelState.IsValid)
                                          {
                                              return requestMessage.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                                          }
                                          else
                                          {
                                              var ids = new JavaScriptSerializer().Deserialize<List<int>>(listIds);

                                              var models = new List<Product>();

                                              foreach( var id in ids)
                                              {
                                                  models.Add(_productService.Delete(id));
                                              }

                                              _productService.SaveChanges();

                                              var responseData = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(models);

                                              return requestMessage.CreateResponse(HttpStatusCode.OK, responseData);
                                          }
                                      });
        }
    }
}
