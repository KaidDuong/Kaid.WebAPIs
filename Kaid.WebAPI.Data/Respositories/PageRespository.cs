using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;

namespace Kaid.WebAPI.Data.Respositories
{
    public interface IPageRespository
    {
    }

    public class PageRespository : RespositoryBase<Page>, IPageRespository
    {
        public PageRespository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}