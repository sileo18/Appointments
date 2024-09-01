using System.ComponentModel.DataAnnotations;

namespace Appointments_API.Models.Dto
{
    public class ProfessionalCreateDTO
    {
        [Required]
        [MaxLength(30)]
        public string name { get; set; }

        [Required]
        public string description { get; set; }
    }
}
