using Kaid.WebAPI.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kaid.WebAPI.Model.Models
{
    [Table("Post")]
    public class Post : Auditable
    {
        public int? ParentID { set; get; }
        public int? DisplayOrder { set; get; }
        public int CategoryID { set; get; }

        [ForeignKey("CategoryID")]
        public virtual PostCategory PostCategory { set; get; }
     //   public virtual  IEnumerable <PostTag> PostTags { set; get; }
    }
}