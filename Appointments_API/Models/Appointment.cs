using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Appointments_API.Models
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]     
        public int Id { get; set; }
        public DateTime DateTime { get; set; }

        // Foreign keys for ProfessionalService
        public int ProfessionalId { get; set; }
        public int ServiceId { get; set; }

        // Navigation properties
        public Professional Professional { get; set; }
        public Service Service { get; set; }
        public User User { get; set; }

    }
}
