using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;

namespace Kaid.WebAPI.Data.Repositories
{
    public interface IMenuRepository:IRepository<Menu>
    {
    }

    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository (IDbFactory dbFactory) :base(dbFactory)
        {

        }
    }
}