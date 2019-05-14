using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;

namespace Kaid.WebAPI.Data.Respositories
{
    public interface IProductTagRespository
    {
    }

    public class ProductTagRespository : RespositoryBase<ProductTag>, IProductTagRespository
    {
        public ProductTagRespository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}