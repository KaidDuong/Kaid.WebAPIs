using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaid.WebAPI.Data.Repositories
{
    public interface IErrorRepository:IRepository<Error> { }
   public class ErrorRepository :RepositoryBase<Error>, IErrorRepository 
    {
        public ErrorRepository(IDbFactory dbFactory): base(dbFactory) { }
    }
}
