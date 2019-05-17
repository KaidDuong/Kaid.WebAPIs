using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;

namespace Kaid.WebAPI.Data.Repositories
{
    public interface IPostTagRepository : IRepository<PostTag> { }

    public class PostTagRepository : RepositoryBase<PostTag>, IPostTagRepository
    {
        public PostTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}