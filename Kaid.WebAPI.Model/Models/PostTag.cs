using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kaid.WebAPI.Model.Models
{
    [Table("PostTags")]
    public class PostTag
    {
        [Key]
        [Column(Order=1,TypeName="varchar")]
        [MaxLength(50)]
        public string TagID { set; get; }
       
        [Key]
        [Column(Order=2)]
        public int PostID { set; get; }

        [ForeignKey("TagID")]
        public virtual Tag Tag { set; get; }

        [ForeignKey("PostID")]
        public virtual Post Post { set; get; }
    }
}