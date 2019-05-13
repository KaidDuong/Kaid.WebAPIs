using Kaid.WebAPI.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kaid.WebAPI.Model.Models
{
    [Table("Pages")]
    public class Page : ISeoable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [Required]
        [MaxLength(256)]
        [Column(TypeName ="varchar")]
        public string Alias { set; get; }
        public string Content { set; get; }
        public string MetaKeyword { set; get; }
        public string MetaDescription { set; get; }
        public bool Status { set; get; }
    }
}