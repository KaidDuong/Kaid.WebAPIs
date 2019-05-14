using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaid.WebAPI.Data.Respositories
{
    public interface IMenuGroupRespository
    {

    }
   public  class MenuGroupRespository : RespositoryBase<MenuGroup>, IMenuGroupRespository
    {
        public MenuGroupRespository(DbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
