using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace Kaid.WebAPI.Data.Repositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        IEnumerable<ProductCategory> GetByAlias(string alias);
    }
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>,IProductCategoryRepository
    {
        
        public ProductCategoryRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            return this.DbContext.ProductCategories.Where(k => k.Alias == alias);
        }
    }
}