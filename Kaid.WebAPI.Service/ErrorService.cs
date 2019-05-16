using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Data.Respositories;
using Kaid.WebAPI.Model.Models;

namespace Kaid.WebAPI.Service
{
    public interface IErrorService
    {
        Error Create(Error error);

        void Save();
    }

    public class ErrorService : IErrorService
    {
        private IErrorRespository _errorResposiory;
        private IUnitOfWork _unitOfWork;

        public ErrorService(IErrorRespository errorRespository,
            IUnitOfWork unitOfWork)
        {
            _errorResposiory = errorRespository;
            _unitOfWork = unitOfWork;
        }

        public Error Create(Error error)
        {
            return _errorResposiory.Add(error);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}