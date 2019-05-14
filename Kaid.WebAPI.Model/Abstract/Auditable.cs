using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kaid.WebAPI.Model.Abstract
{
    public abstract class Auditable : IAuditable, ISeoable, ISwitchable, IInformatable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       
        public int ID { get; set; }

        [MaxLength(256)]
        [Required]
        public string Name { get; set; }

        [Column(TypeName ="varchar")]
        [MaxLength(256)]
        [Required]
        public string Alias { get; set; }

        [MaxLength(500)]
        public string Image { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public DateTime? CreateDate { set; get; }

        [MaxLength(256)]
        public string CreateBy { set; get; }

        public DateTime? UpdateDate { set; get; }

        [MaxLength(256)]
        public string UpdateBy { set; get; }

        public bool Status { set; get; }
        public bool? HomeFlag { set; get; }

        [MaxLength(256)]
        public string MetaKeyword { set; get; }

        [MaxLength(256)]
        public string MetaDescription { set; get; }
    }
}