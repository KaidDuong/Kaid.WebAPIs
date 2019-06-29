namespace Kaid.WebAPI.Web.Models.ViewModels
{
    public class SlideViewModel
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
       
        public string Alias { get; set; }
        
        public string Image { get; set; }

        public string Description { get; set; }
        
        public string URL { set; get; }

        public int? DisplayOrder { set; get; }
        public bool Status { set; get; }
        public string Content { set; get; }
    }
}