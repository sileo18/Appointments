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
        public DbSet<ProfessionalService> professionalServices { get; set; }
        public DbSet<Appointment> appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProfessionalService>()
                .HasKey(ps => new { ps.ProfessionalId, ps.ServiceId });

            modelBuilder.Entity<ProfessionalService>()
                .HasOne(ps => ps.Professional)
                .WithMany(p => p.ProfessionalServices)
                .HasForeignKey(ps => ps.ProfessionalId);

            modelBuilder.Entity<ProfessionalService>()
                .HasOne(ps => ps.Service)
                .WithMany(s => s.ProfessionalServices)
                .HasForeignKey(ps => ps.ServiceId);
        }

    }
}
