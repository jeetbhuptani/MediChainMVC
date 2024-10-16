using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MediChain.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
