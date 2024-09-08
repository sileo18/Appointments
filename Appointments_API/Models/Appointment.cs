using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointments_API.Models;

public partial class Appointment
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public DateTime DateTime { get; set; }    

    public string? Title { get; set; }

    public int? JobId { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }   

    public virtual Job? Job { get; set; }
    
}
