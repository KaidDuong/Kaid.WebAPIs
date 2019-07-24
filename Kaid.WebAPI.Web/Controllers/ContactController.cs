using Kaid.WebAPI.Model.Models;
using Kaid.WebAPI.Service;
using Kaid.WebAPI.Web.Models.ViewModels;
using System.Web.Mvc;

namespace Kaid.WebAPI.Web.Controllers
{
    public class ContactController : Controller
    {
        private IContactDetailService _contactDetailService;

        public ContactController(IContactDetailService contactDetailService) => _contactDetailService = contactDetailService;

        // GET: Contact
        public ActionResult Index()
        {
            var modelContact = _contactDetailService.GetContactDetailDefault();

            var viewModelContact = AutoMapper.Mapper.Map<ContactDetail, ContactDetailViewModel>(modelContact);

            return View(viewModelContact);
        }
    }
}