using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaid.WebAPI.Data.Respositories
{
    public interface IProductRespository : IRespository<Product>
    {

    }
    public class ProductRespository
         : RespositoryBase<ProductCategoryRespository>, IProductRespository
    {
        
        public ProductRespository (DbFactory dbFactory)
            : base(dbFactory) { }
    }
}
