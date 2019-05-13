using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kaid.WebAPI.Model.Models
{
    [Table("SystemConfigs")]
    public class SystemConfig
    {
        [Key]
        public int ID { set; get; }

        [Column(TypeName ="varchar")]
        [Required]
        [MaxLength(50)]
        public string Code { set; get; }
        [MaxLength(50)]
        public string ValueString { set; get; }
        public int? ValueInt { set; get; }
    }
}