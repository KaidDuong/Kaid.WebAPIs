using Kaid.WebAPI.Web.Models.Abstract;
using System.Collections.Generic;

namespace Kaid.WebAPI.Web.Models
{
    public class PostViewModel : Auditable
    {
        public int? ParentID { set; get; }
        public int? DisplayOrder { set; get; }
        public int CategoryID { set; get; }
        public string Content { set; get; }
        public int ViewCount { get; set; }

        public virtual PostCategoryViewModel PostCategory { set; get; }
        public virtual IEnumerable<PostTagViewModel> PostTags { set; get; }
    }
}