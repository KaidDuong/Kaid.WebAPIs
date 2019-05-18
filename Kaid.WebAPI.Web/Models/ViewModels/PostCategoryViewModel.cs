using Kaid.WebAPI.Web.Models.Abstract;
using System.Collections.Generic;

namespace Kaid.WebAPI.Web.Models
{
    public class PostCategoryViewModel : Auditable
    {
        public int? ParentID { set; get; }
        public int? DisplayOrder { set; get; }
        public virtual IEnumerable<PostViewModel> Posts { set; get; }
    }
}