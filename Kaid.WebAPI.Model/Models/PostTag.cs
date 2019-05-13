using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kaid.WebAPI.Model.Models
{
    [Table("PostTags")]
    public class PostTag
    {
        [Key]
        [Column(TypeName ="varchar")]
        [MaxLength(50)]
        public string TagID { set; get; }
       
        [Key]
        public int PostID { set; get; }
        [ForeignKey("TagID")]
       
        public virtual Tag Tag { set; get; }
        [ForeignKey("PostID")]
        public virtual Post Post { set; get; }
    }
}