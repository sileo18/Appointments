using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointments_API.Models;

public partial class Job
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int? Professionalld { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }    

    public decimal? Cost { get; set; }

    public virtual ICollection<Appointment> Appointments { get; } = new List<Appointment>();

    public virtual Professional? ProfessionalldNavigation { get; set; }
}
