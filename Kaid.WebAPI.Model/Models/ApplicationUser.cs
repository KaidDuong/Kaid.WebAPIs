using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kaid.WebAPI.Model.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(256)]
        [Required]
        public string FullName { set; get; }

        [MaxLength(256)]
        public String Address { get; set; }

        public DateTime? Birthday { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync
            (UserManager<ApplicationUser> userManager)
        {
            //note the authenticationType must mach the one defined in CookieAuthenticationOptions.AuthencationType
            var userIdentity = await userManager.CreateIdentityAsync
                (this,DefaultAuthenticationTypes.ApplicationCookie);
            //add custom user claims here
            return userIdentity;
        }
    }
}