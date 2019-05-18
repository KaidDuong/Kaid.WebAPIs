namespace Kaid.WebAPI.Web.Models.Abstract
{
    public interface ISwitchable
    {
        bool Status { set; get; }
        bool? HomeFlag { set; get; }
    }
}