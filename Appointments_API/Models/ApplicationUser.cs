using Microsoft.AspNetCore.Identity;

namespace Appointments_API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
