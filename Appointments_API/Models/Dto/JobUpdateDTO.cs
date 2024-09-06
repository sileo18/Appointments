using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointments_API.Models.Dto
{
    public class JobUpdateDTO
    {        
        
        public int id { get; set; }

        [Required]
        [MaxLength(30)]
        public string name { get; set; }

        [Required]
        [MaxLength(200)]
        public string description { get; set; }

        [Required]
        public double cost { get; set; }

        [Required]
        public int ProfessionalId { get; set; }
        
    }
}
