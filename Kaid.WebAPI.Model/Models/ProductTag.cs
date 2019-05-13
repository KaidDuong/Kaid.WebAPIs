using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kaid.WebAPI.Model.Models
{
    [Table("ProductTags")]
    public class ProductTag
    {
        [Key]
        [MaxLength(50)]
        [Column(TypeName ="varchar")]
        public string TagID { set; get; }

        [Key]
        public int ProductID { get; set; }

        [ForeignKey("TagID")]
        public virtual Product Product { set; get; }

        [ForeignKey("TagID")]
        public virtual Tag Tag { set; get; }

    }
}