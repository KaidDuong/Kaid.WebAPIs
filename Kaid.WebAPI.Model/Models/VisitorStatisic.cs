using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kaid.WebAPI.Model.Models
{
    [Table("VisitorStatisics")]
    public class VisitorStatisic
    {
        [Key]
        public Guid ID { set; get; }
        [Required]
        public DateTime VisitedDate { set; get; }

        [Required]
        [MaxLength(50)]
        public string IPAddress { set; get; }
    }
}