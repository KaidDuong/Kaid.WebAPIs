using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;

namespace Kaid.WebAPI.Data.Repositories
{
    public interface IFooterRepository: IRepository<Footer>
    {
    }

    public class Footer : RepositoryBase<Footer>, IFooterRepository
    {
        public Footer(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}