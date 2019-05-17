using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Data.Repositories;
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
        private IErrorRepository _errorReposiory;
        private IUnitOfWork _unitOfWork;

        public ErrorService(IErrorRepository errorRepository,
            IUnitOfWork unitOfWork)
        {
            _errorReposiory = errorRepository;
            _unitOfWork = unitOfWork;
        }

        public Error Create(Error error)
        {
            return _errorReposiory.Add(error);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}