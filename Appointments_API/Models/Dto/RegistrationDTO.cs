using System.ComponentModel.DataAnnotations;

namespace Appointments_API.Models.Dto
{
    public class RegistrationDTO
    {


        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
    }
}
