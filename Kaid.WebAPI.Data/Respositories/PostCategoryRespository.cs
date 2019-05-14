using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;

namespace Kaid.WebAPI.Data.Respositories
{
    public interface IPostCategoryRespository : IRespository<PostCategory> { }
   public class PostCategoryRespository: RespositoryBase<PostCategory>, IPostCategoryRespository
    {
        public PostCategoryRespository(DbFactory dbFactory): base(dbFactory) { }
    }
}