using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kaid.WebAPI.Model.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(300)]
        public string CustomerName { set; get; }

        [Required]
        [MaxLength(300)]
        public string CustomerAddress { set; get; }

        [Required]
        [MaxLength(50)]
        public string CustomerMoble { set; get; }

        [Required]
        [MaxLength(300)]
        public string CustomerEmail { set; get; }

        [MaxLength(300)]
        public string CustomerMessage { set; get; }

        public DateTime? CreateDate { set; get; }

        
        [MaxLength(200)]
        public string CreateBy { set; get; }

        
        [MaxLength(250)]
        public string PaymentMethod { set; get; }

        [Required]
        [MaxLength(50)]
        public string PaymentStatus { set; get; }

        public bool Status { set; get; }
        
        public virtual IEnumerable<OrderDetail> OrderDetails { set; get; }
        
    }
}