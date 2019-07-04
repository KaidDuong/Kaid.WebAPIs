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
            return View();
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