using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaid.WebAPI.Model.Models
{
    [Table("SupportOnlines")]
   public class SupportOnline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        [MaxLength(50)]

        public  string Name { get; set; }
        [MaxLength(50)]
        public string Department { get; set; }
        [MaxLength(50)]
        public string Skype { get; set; }

        [MaxLength(50)]
        public string  Moble { get; set; }
        [MaxLength(50)]
        public string  Email { get; set; }
        [MaxLength(50)]
        public string  Yahoo { get; set; }
        [MaxLength(50)]
        public string Facebook { get; set; }
        public bool Status { get; set; }
    }
}
