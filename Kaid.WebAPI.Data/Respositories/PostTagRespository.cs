using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;

namespace Kaid.WebAPI.Data.Respositories
{
    public interface IPostTagRespository { }

    public class PostTagRespository : RespositoryBase<PostTag>, IPostTagRespository
    {
        public PostTagRespository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}