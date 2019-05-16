using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaid.WebAPI.Data.Respositories
{
    public interface IErrorRespository:IRespository<Error> { }
   public class ErrorRespository :RespositoryBase<Error>, IErrorRespository 
    {
        public ErrorRespository(DbFactory dbFactory): base(dbFactory) { }
    }
}
