using Appointments_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Appointments_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        DbSet<User> users { get; set; }
        DbSet<Professional> professionals { get; set; }
        DbSet<Service> services { get; set; }
        DbSet<Appointment> appointments { get; set; }   
    }
}
