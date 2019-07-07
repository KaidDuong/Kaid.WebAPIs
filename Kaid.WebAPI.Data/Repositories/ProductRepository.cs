using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaid.WebAPI.Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProductsFromTag(string tagID);
    }
    public class ProductRepository
         : RepositoryBase<Product>, IProductRepository
    {
        
        public ProductRepository (IDbFactory dbFactory)
            : base(dbFactory) { }

        public IEnumerable<Product> GetProductsFromTag(string tagID)
        {
        return from p in DbContext.Products
                   join pt in DbContext.ProductTags
                   on p.ID equals pt.ProductID
                   where pt.TagID == tagID
                   select p;     
        }
    }
}
