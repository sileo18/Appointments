using Appointments_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Appointments_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> users { get; set; }
        public DbSet<Professional> professionals { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<Appointment> appointments { get; set; }   
    }
}
