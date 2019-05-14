using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;

namespace Kaid.WebAPI.Data.Respositories
{
    public interface ITagRespository { }

    public class TagRespository : RespositoryBase<Tag>, ITagRespository
    {
        public TagRespository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}