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

        [ForeignKey("Professional")]
        public int ProfessionalId { get; set; }
        public Professional Professional { get; set; }

        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        

    }
}
