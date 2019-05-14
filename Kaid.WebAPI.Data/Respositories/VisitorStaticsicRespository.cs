using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;

namespace Kaid.WebAPI.Data.Respositories
{
    public interface IVisitorStaticsic : IRespository<VisitorStatisic> { }

    public class VisitorStaticsicRespository : RespositoryBase<VisitorStatisic>, IVisitorStaticsic
    {
        public VisitorStaticsicRespository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}