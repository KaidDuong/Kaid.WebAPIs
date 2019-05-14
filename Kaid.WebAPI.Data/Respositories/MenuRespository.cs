using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;

namespace Kaid.WebAPI.Data.Respositories
{
    public interface IMenuRespository
    {
    }

    public class MenuRespository : RespositoryBase<Menu>, IMenuRespository
    {
        public MenuRespository (DbFactory dbFactory) :base(dbFactory)
        {

        }
    }
}