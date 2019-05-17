using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace Kaid.WebAPI.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow);
    }

    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from p in DbContext.Posts
                        join ptag in DbContext.PostTags
                        on p.ID equals ptag.PostID
                        where ptag.TagID == tag && p.Status
                        orderby p.CreateDate descending
                        select p;
            totalRow = query.Count();
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query;
        }
    }
}