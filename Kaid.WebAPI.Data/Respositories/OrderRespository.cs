using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;

namespace Kaid.WebAPI.Data.Respositories
{
    public interface IOrderRespository
    {
    }

    public class OrderRespository : RespositoryBase<Order>, IOrderRespository
    {
        public OrderRespository (DbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}