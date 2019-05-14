using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;

namespace Kaid.WebAPI.Data.Respositories
{
    public interface IOrderDetailRespository : IRespository<OrderDetail>
    {
    }

    public class OrderDetailRespository : RespositoryBase<OrderDetail>, IOrderDetailRespository
    {
        public OrderDetailRespository(DbFactory dbFactory) : base(dbFactory)
        {
           
        }
    }
}