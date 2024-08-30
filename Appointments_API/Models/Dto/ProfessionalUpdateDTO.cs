using System.ComponentModel.DataAnnotations;

namespace Appointments_API.Models.Dto
{
    public interface ProfessionalUpdateDTO
    {
        [Required]
        public int id { get; set; }

        [Required]
        [MaxLength(30)]
        public string name { get; set; }

        [Required]
        public string servicesProvided { get; set; }
    }
}
