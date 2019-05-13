namespace Kaid.WebAPI.Model.Abstract
{
    public interface ISwitchable
    {
        bool Status { set; get; }
        bool? HomeFlag { set; get; }
    }
}