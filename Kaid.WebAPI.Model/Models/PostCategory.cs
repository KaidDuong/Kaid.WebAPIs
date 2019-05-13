﻿using Kaid.WebAPI.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kaid.WebAPI.Model.Models
{
    [Table("PostCategories")]
    public class PostCategory : Auditable
    {
        public int? ParentID { set; get; }
        public int? DisplayOrder { set; get; }
        public virtual IEnumerable<Post> Posts { set; get; }
      
    }
}