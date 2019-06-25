using AutoMapper;
using Kaid.WebAPI.Model.Models;
using Kaid.WebAPI.Service;
using Kaid.WebAPI.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kaid.WebAPI.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductCategoryService _productCategoryService;
        private ICommonService _commonService;

        public HomeController(IProductCategoryService productCategoryService,ICommonService commonService)
        {
            this._productCategoryService = productCategoryService;
            this._commonService = commonService;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Category()
        {
            var models = _productCategoryService.GetAll();

            var viewModels = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(models);

            return PartialView(viewModels);
        }
        [ChildActionOnly]
        public ActionResult Footer()
        {
            var footerModels = _commonService.GetFooter();

            var footerViewModels = Mapper.Map<Footer, FooterViewModel>(footerModels);

            return PartialView(footerViewModels);
        }
    }
}