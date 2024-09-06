using System.ComponentModel.DataAnnotations;

namespace Appointments_API.Models.Dto
{
    public class CustomerDTO
    {        
        public int id { get; set; } 

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [EmailAddress] 
        [MaxLength(255)] 
        public string Email { get; set; }

        public string? Password { get; set; } 

        public string? Phone { get; set; } 
    }
}
