using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;

namespace Kaid.WebAPI.Data.Respositories
{
    public interface ISupportOnlineRespository { }

    public class SupportOnlineRespository : RespositoryBase<SupportOnline>, ISupportOnlineRespository
    {
        public SupportOnlineRespository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}