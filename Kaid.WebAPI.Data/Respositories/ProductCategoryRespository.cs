using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace Kaid.WebAPI.Data.Respositories
{
    public interface IProductCategoryRespository
    {
        IEnumerable<ProductCategory> GetByAlias(string alias);
    }
    public class ProductCategoryRespository : RespositoryBase<ProductCategory>,IProductCategoryRespository
    {
        
        public ProductCategoryRespository(DbFactory dbFactory)
            : base(dbFactory) { }

        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            return this.DbContext.ProductCategories.Where(k => k.Alias == alias);
        }
    }
}