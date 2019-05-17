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

    }
    public class ProductRepository
         : RepositoryBase<Product>, IProductRepository
    {
        
        public ProductRepository (IDbFactory dbFactory)
            : base(dbFactory) { }
    }
}
