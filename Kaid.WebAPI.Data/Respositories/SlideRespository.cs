using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Model.Models;

namespace Kaid.WebAPI.Data.Respositories
{
    public interface ISlideRespository { }

    public class SlideRespository : RespositoryBase<Slide>, ISlideRespository
    {
        public SlideRespository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}