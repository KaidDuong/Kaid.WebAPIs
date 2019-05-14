using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;

namespace Kaid.WebAPI.Data.Respositories
{
    public interface IPostRespository : IRespository<Post> { }

    public class PostRespository : RespositoryBase<Post>, IPostRespository
    {
        public PostRespository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}