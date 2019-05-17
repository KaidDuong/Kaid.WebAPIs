using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;

namespace Kaid.WebAPI.Data.Repositories
{
    public interface IPostCategoryRepository : IRepository<PostCategory> { }
   public class PostCategoryRepository: RepositoryBase<PostCategory>, IPostCategoryRepository
    {
        public PostCategoryRepository(IDbFactory dbFactory): base(dbFactory) { }
    }
}