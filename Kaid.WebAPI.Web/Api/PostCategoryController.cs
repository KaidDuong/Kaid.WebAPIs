using AutoMapper;
using Kaid.WebAPI.Model.Models;
using Kaid.WebAPI.Service;
using Kaid.WebAPI.Web.Infrastructure.Core;
using Kaid.WebAPI.Web.Infrastructure.Extentions;
using Kaid.WebAPI.Web.Models.ViewModels;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kaid.WebAPI.Web.Api
{
    [RoutePrefix("api/postCategory")]
    public class PostCategoryController : ApiControllerBase
    {
        private IPostCategoryService _postCategoryService;

        public PostCategoryController(IErrorService errorService,
            IPostCategoryService postCategoryService) : base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage Get
            (HttpRequestMessage requestMessage)
        {
            return CreateHttpResponse(requestMessage, () =>
            {
                var categorys = _postCategoryService.GetAll();
                var postCategoryViewModels = Mapper.Map<List<PostCategoryViewModel>>(categorys);

                return requestMessage.CreateResponse(HttpStatusCode.OK, postCategoryViewModels);
            });
        }
        [Route("add")]
        public HttpResponseMessage Post
            (HttpRequestMessage requestMessage, PostCategoryViewModel postCategoryVm)
        {
            return CreateHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage responseMessage = null;
                if (ModelState.IsValid)
                {
                    requestMessage.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var postCategory = new PostCategory();
                    postCategory.UpdatePostCategory(postCategoryVm);

                    var category = _postCategoryService.Add(postCategory);
                    _postCategoryService.SaveChanges();

                    responseMessage = requestMessage.CreateResponse(HttpStatusCode.Created, category);
                }
                return responseMessage;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put
           (HttpRequestMessage requestMessage, PostCategoryViewModel postCategoryVm)
        {
            return CreateHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage responseMessage = null;
                if (ModelState.IsValid)
                {
                    requestMessage.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var postCategory = _postCategoryService.GetById(postCategoryVm.ID);
                    postCategory.UpdatePostCategory(postCategoryVm);

                    _postCategoryService.Update(postCategory);
                    _postCategoryService.SaveChanges();

                    responseMessage = requestMessage.CreateResponse(HttpStatusCode.OK);
                }
                return responseMessage;
            });
        }

        public HttpResponseMessage Delete
           (HttpRequestMessage requestMessage, PostCategoryViewModel postCategoryVm)
        {
            return CreateHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage responseMessage = null;
                if (ModelState.IsValid)
                {
                    requestMessage.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    
                    var category = _postCategoryService.Delete(postCategoryVm.ID);
                    _postCategoryService.SaveChanges();

                    var postCategoryViewModel = Mapper.Map<PostCategoryViewModel>(category);
                    responseMessage = requestMessage.CreateResponse(HttpStatusCode.OK, postCategoryViewModel);
                }
                return responseMessage;
            });
        }
    }
}