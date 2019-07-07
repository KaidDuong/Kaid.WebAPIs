using Kaid.WebAPI.Common;
using Kaid.WebAPI.Model.Models;
using Kaid.WebAPI.Service;
using Kaid.WebAPI.Web.Infrastructure.Core;
using Kaid.WebAPI.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Kaid.WebAPI.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        private IProductCategoryService _productCategoryService;

        public ProductController(IProductService productService, IProductCategoryService productCategoryService)
        {
            this._productCategoryService = productCategoryService;
            this._productService = productService;
        }

        // GET: Product
        public ActionResult Category(int categoryId, int page=1, string sort="")
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize")); 
            int totalRow = 0;

            var productModels = _productService.GetProductsByCategoryIdPaging(categoryId, page, pageSize,sort, out totalRow);
            var productViewModels = AutoMapper.Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModels);

            int totalPages =(int)Math.Ceiling((double)totalRow / pageSize);

            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productViewModels,
                MaxPage= int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page=page,
                TotalCount=totalRow,
                TotalPages= totalPages
        };

            var categoryModel = _productCategoryService.GetById(categoryId);
            var categoryViewModel = AutoMapper.Mapper.Map<ProductCategory, ProductCategoryViewModel>(categoryModel);
            ViewBag.Category = categoryViewModel;

            return View(paginationSet);

        }

        public ActionResult Search(string keyword, int page = 1, string sort = "")
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;

            var productModels = _productService.GetProductsByNamePaging(keyword, page, pageSize, sort, out totalRow);
            var productViewModels = AutoMapper.Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModels);

            int totalPages = (int)Math.Ceiling((double)totalRow / pageSize);

            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productViewModels,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPages
            };

            
            ViewBag.Keyword = keyword;

            return View(paginationSet);

        }

        public ActionResult Detail(int productId)
        {
            _productService.IncreaseView(productId);

            var model = _productService.GetById(productId);
            var viewModel = AutoMapper.Mapper.Map<Product, ProductViewModel>(model);

            var numberOfRelatedProducts = Convert.ToInt32(ConfigHelper.GetByKey("NumberOfRelatedProducts"));

            var relatedProducts = _productService.GetRelatedProducts(productId, numberOfRelatedProducts);
            ViewBag.RelatedProducts = AutoMapper.Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(relatedProducts);

            var moreImages = new JavaScriptSerializer().Deserialize<List<String>>(model.MoreImages);
            ViewBag.MoreImages = moreImages;

            var tags = _productService.GetTagsBy(productId);
            ViewBag.Tags = AutoMapper.Mapper.Map<IEnumerable<Tag>, IEnumerable<TagViewModel>>(tags);

            return View(viewModel);
        }
        
        public ActionResult ProductsFromTag(string tagId, int page = 1)
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;

            var productModels = _productService.GetProductsByTagIdPaging(tagId, page, pageSize, out totalRow);
            var productViewModels = AutoMapper.Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModels);

            int totalPages = (int)Math.Ceiling((double)totalRow / pageSize);

            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productViewModels,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPages
            };

            var tag = _productService.GetTag(tagId);
            ViewBag.Tag = AutoMapper.Mapper.Map<Tag, TagViewModel>(tag);

            return View(paginationSet);
        }
        public JsonResult GetProductsByName(string keyword)
        {
           var responseData= _productService.GetProductsByName(keyword);
            return Json(new {
                data = responseData
            },JsonRequestBehavior.AllowGet);
        }
    }
}