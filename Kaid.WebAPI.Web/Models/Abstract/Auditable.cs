using System;
using System.ComponentModel.DataAnnotations;

namespace Kaid.WebAPI.Web.Models.Abstract
{
    public abstract class Auditable : IAuditable, ISeoable, ISwitchable, IInformatable
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Alias { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public DateTime? CreateDate { set; get; }

        public string CreateBy { set; get; }

        public DateTime? UpdateDate { set; get; }

        public string UpdateBy { set; get; }

        [Required]
        public bool Status { set; get; }

        public bool? HomeFlag { set; get; }

        public string MetaKeyword { set; get; }

        public string MetaDescription { set; get; }
    }
}