using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kaid.WebAPI.Model.Models
{
    [Table("Footers")]
    public class Footer
    {
        [Key]
        [Required]
        [MaxLength(50)]
        public string ID { set; get; }

        [Required]
        public string Content { set; get; }
    }
}