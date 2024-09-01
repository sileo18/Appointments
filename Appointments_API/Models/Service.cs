using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Appointments_API.Models
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double cost { get; set; }

        [ForeignKey("Professional")]
        public int ProfessionalId { get; set; }
        public Professional Professional { get; set; }
    }
}
