namespace Kaid.WebAPI.Web.Models
{
    public class PostTagViewModel
    {
        
        public string TagID { set; get; }

        public int PostID { set; get; }
        
        public virtual TagViewModel Tag { set; get; }
        
        public virtual PostViewModel Post { set; get; }
    }
}