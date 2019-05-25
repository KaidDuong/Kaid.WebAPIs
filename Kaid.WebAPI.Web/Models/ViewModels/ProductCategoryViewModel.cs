using Kaid.WebAPI.Web.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kaid.WebAPI.Web.Models.ViewModels
{
    public class ProductCategoryViewModel : Auditable
    {
        public int? ParentID { set; get; }
        public int? DisplayOrder { set; get; }

        public virtual IEnumerable<ProductViewModel> Products { set; get; }
    }
}
