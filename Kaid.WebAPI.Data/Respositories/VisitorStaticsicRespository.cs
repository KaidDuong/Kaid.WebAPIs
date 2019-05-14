using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;

namespace Kaid.WebAPI.Data.Respositories
{
    public interface IVisitorStaticsic { }

    public class VisitorStaticsicRespository : RespositoryBase<VisitorStatisic>, IVisitorStaticsic
    {
        public VisitorStaticsicRespository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}