using Kaid.WebAPI.Common;
using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Data.Repositories;
using Kaid.WebAPI.Model.Models;

namespace Kaid.WebAPI.Service
{
    public interface ICommonService
    {
        Footer GetFooter();
    }

    public class CommonService : ICommonService
    {
        private IFooterRepository _footerRepository;
        private IUnitOfWork _unitOfWork;

        public CommonService(IFooterRepository footerRepository, IUnitOfWork unitOfWork)
        {
            this._footerRepository = footerRepository;
            this._unitOfWork = unitOfWork;
        }

        public Footer GetFooter()
        {
            return _footerRepository.GetSingleByCondition(k=>k.ID== CommonConstants.FooterIdDefault);
        }
    }
}