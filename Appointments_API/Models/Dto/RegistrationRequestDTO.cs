using System.ComponentModel.DataAnnotations;

namespace Appointments_API.Models.Dto
{
    public class RegistrationRequestDTO
    {        
        public string Username { get; set; }        
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
