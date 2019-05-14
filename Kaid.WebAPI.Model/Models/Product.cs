using Kaid.WebAPI.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Kaid.WebAPI.Model.Models
{
    [Table("Products")]
    public class Product : Auditable
    {
        public int CategoryID { set; get; }

        [Column(TypeName = "xml")]
        public string MoreImages { set; get; }
        public decimal Price { set; get; }
        public decimal? PromotionPrice { set; get; }
        public int? Warranty { set; get; }

        [Required]
        public string Content { set; get; }
        
        public bool? HotFlag { set; get; }
        public int? ViewCount { set; get; }

        [ForeignKey("CategoryID")]
        public virtual  ProductCategory ProductCategory { set; get; }
       // public virtual IEnumerable<ProductTag> ProductTags { set; get; }


    }
}