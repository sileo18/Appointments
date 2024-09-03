using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Appointments_API.Models
{
    public class Professional
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        
    }
}
