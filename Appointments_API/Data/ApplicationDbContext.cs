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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appointment>()
                .HasOne(s => s.Service)
                .WithMany()
                .HasForeignKey(s => s.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(s => s.Professional)
                .WithMany()
                .HasForeignKey(s => s.ProfessionalId)
                .OnDelete(DeleteBehavior.Restrict); ;
        }

    }
}
