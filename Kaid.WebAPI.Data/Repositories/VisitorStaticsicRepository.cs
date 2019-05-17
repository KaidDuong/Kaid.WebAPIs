using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;

namespace Kaid.WebAPI.Data.Repositories
{
    public interface IVisitorStaticsicRepository : IRepository<VisitorStatisic> { }

    public class VisitorStaticsicRepository : RepositoryBase<VisitorStatisic>, IVisitorStaticsicRepository
    {
        public VisitorStaticsicRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

}