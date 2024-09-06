using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointments_API.Models.Dto   
{
    public class JobDTO
    {

        public int id { get; set; }

        [Required]
        [MaxLength(30)]
        public string name { get; set; }

        [MaxLength(200)]
        public string description { get; set; }


        public double cost { get; set; }

        [Required]
        public int ProfessionalId { get; set; }

    }
}
