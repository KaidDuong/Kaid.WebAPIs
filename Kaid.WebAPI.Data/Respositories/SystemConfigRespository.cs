using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;

namespace Kaid.WebAPI.Data.Respositories
{
    public interface ISystemConfig : IRespository<SystemConfig> { }

    public class SystemConfigRespository : RespositoryBase<SystemConfig>, ISystemConfig
    {
        public SystemConfigRespository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}