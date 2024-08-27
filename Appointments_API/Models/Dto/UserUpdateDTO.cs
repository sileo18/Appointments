using System.ComponentModel.DataAnnotations;

namespace Appointments_API.Models.Dto
{
    public class UserUpdateDTO
    {
        [Required]
        public int id { get; set; }
        [Required]
        [MaxLength(30)]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string phone { get; set; }
    }
}
