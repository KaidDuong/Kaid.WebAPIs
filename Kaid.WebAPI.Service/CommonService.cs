using Kaid.WebAPI.Common;
using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Data.Repositories;
using Kaid.WebAPI.Model.Models;
using System.Collections.Generic;

namespace Kaid.WebAPI.Service
{
    public interface ICommonService
    {
        Footer GetFooter();
        IEnumerable<Slide> GetSlides();
    }

    public class CommonService : ICommonService
    {
        private IFooterRepository _footerRepository;
        private ISlideRepository _slideRepository;
        private IUnitOfWork _unitOfWork;

        public CommonService(IFooterRepository footerRepository,
                             IUnitOfWork unitOfWork,
                             ISlideRepository slideRepository
                             )
        {
            this._footerRepository = footerRepository;
            this._unitOfWork = unitOfWork;
            this._slideRepository = slideRepository;        }

        public Footer GetFooter()
        {
            return _footerRepository.GetSingleByCondition(k=>k.ID== CommonConstants.FooterIdDefault);
        }

        public IEnumerable<Slide> GetSlides()
        {
            return _slideRepository.GetMulti(k=>k.Status);
        }
    }
}