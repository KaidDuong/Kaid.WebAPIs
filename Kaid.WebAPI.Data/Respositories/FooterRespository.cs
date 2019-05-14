using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;

namespace Kaid.WebAPI.Data.Respositories
{
    public interface IFooterRespository:IRespository<Footer>
    {
    }

    public class FooterRespository : RespositoryBase<Footer>, IFooterRespository
    {
        public FooterRespository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}