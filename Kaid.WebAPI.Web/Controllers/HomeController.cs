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
        private IProductService _productService;
        
        public HomeController(IProductCategoryService productCategoryService,
                              ICommonService commonService,
                              IProductService productService
                              )
        {
            this._productCategoryService = productCategoryService;
            this._commonService = commonService;
            this._productService = productService;
        }
        // GET: Home
        public ActionResult Index()
        {
            var slideModels = _commonService.GetSlides();
            var lastestProductModels = _productService.GetLatestProduct(3);
            var hotProductModels = _productService.GetTopSaleProduct(3);

            var slideViewModels = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(slideModels);
            var lastestProductViewModels = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(lastestProductModels);
            var hotProductViewModels = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(hotProductModels);

            var homeViewModel = new HomeViewModel {
                Slides = slideViewModels,
                LastestProducts=lastestProductViewModels,
                TopSaleProducts=hotProductViewModels
            };

            return View(homeViewModel);
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