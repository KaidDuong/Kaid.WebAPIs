using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Data.Repositories;
using Kaid.WebAPI.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaid.WebAPI.Service
{
    public interface IContactDetailService
    {
        ContactDetail GetContactDetailDefault();
    }
    public class ContactDetailService : IContactDetailService
    {
        private IContactDetailRepository _contactDetailRepository;
        private IUnitOfWork _unitOfWork;

        public ContactDetailService( IContactDetailRepository contactDetailRepository, IUnitOfWork unitOfWork)
        {
            _contactDetailRepository = contactDetailRepository;
            _unitOfWork = unitOfWork;
        }
        public ContactDetail GetContactDetailDefault() => _contactDetailRepository.GetSingleByCondition(k => k.Status && k.Id == 1);
        
    }
}
