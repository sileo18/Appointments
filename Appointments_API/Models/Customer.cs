using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointments_API.Models;

public partial class Customer
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual ICollection<Appointment> Appointments { get; } = new List<Appointment>();
}
