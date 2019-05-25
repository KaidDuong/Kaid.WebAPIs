namespace Kaid.WebAPI.Web.Models.ViewModels
{
    public class ProductTagViewModel
    {
       
        public string TagID { set; get; }

       
        public int ProductID { get; set; }
        
        public virtual TagViewModel Tag { set; get; }
        
        public virtual ProductViewModel Product { set; get; }


    }
}