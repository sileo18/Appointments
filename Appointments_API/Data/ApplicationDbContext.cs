using System;
using System.Collections.Generic;
using Appointments_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Appointments_API.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Professional> Professionals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-G54VGEI;Database=AppointmentsDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3214EC0740C0045D");

            entity.Property(e => e.Id).ValueGeneratedNever();           
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Appointme__Custo__5165187F");

            entity.HasOne(d => d.Job).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK__Appointme__JobId__5070F446");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC077E67552C");

            entity.ToTable("Customer");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Job__3214EC0756D44043");

            entity.ToTable("Job");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);           

            entity.HasOne(d => d.ProfessionalldNavigation).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.Professionalld)
                .HasConstraintName("FK__Job__Professiona__4D94879B");
        });

        modelBuilder.Entity<Professional>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Professi__3214EC076D4F4735");

            entity.ToTable("Professional");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
