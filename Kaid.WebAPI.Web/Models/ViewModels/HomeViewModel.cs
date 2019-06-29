using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kaid.WebAPI.Web.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<SlideViewModel> Slides { set; get; }
        public IEnumerable<ProductViewModel> LastestProducts { get; set; }

        public IEnumerable<ProductViewModel> TopSaleProducts { set; get; }
    }
}