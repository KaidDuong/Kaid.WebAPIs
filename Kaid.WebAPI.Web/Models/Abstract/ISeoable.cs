namespace Kaid.WebAPI.Web.Models.Abstract
{
    public interface ISeoable
    {
        string MetaKeyword { set; get; }
        string MetaDescription { set; get; }
    }
}