using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Appointments_API.Models
{
    public class ProfessionalService
    {
        [Key, Column(Order = 0)]

        public int ProfessionalId { get; set; }
        public Professional Professional { get; set; }

        [Key, Column(Order = 1)]
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

    }
}
