using Kaid.WebAPI.Web.Models.Abstract;
using System.Collections.Generic;

namespace Kaid.WebAPI.Web.Models.ViewModels
{
    public class ProductViewModel : Auditable
    {
        public int CategoryID { set; get; }
        public string MoreImages { set; get; }
        public decimal Price { set; get; }
        public decimal? PromotionPrice { set; get; }
        public int? Warranty { set; get; }
        
        public string Content { set; get; }

        public bool? HotFlag { set; get; }
        public int? ViewCount { set; get; }

        public string Tags { set; get; }

        public int Quanlity { set; get; }
        public virtual ProductCategoryViewModel ProductCategory { set; get; }
        public virtual IEnumerable<ProductTagViewModel> ProductTags { set; get; }

    }
}