namespace Kaid.WebAPI.Model.Abstract
{
    public interface IInformatable
    {
        int ID { set; get; }
        string Name { set; get; }
        string Alias { set; get; }
        string Image { set; get; }
        string Description { set; get; }
    }
}