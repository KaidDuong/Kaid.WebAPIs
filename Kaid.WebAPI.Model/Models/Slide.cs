using Kaid.WebAPI.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaid.WebAPI.Model.Models
{
    [Table("Slides")]
    public class Slide : IInformatable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName ="varchar")]
        [MaxLength(256)]
        public string Alias { get; set; }
       
        [MaxLength(256)]
        public string Image { get; set; }
        public string Description { get; set; }
        [MaxLength(256)]
        public string URL { set; get; }
        public int? DisplayOrder { set; get; }
        public bool Status { set; get; }
        public string Content { set; get; }
    }
}
