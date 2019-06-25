using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;

namespace Kaid.WebAPI.Data.Repositories
{
    public interface IFooterRepository : IRepository<Footer>
    {
    }

    public class FooterRepository : RepositoryBase<Footer>, IFooterRepository
    {
        public FooterRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}