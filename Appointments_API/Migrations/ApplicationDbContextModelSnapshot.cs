﻿// <auto-generated />
using System;
using Appointments_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppointmentsAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Appointments_API.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProfessionalId")
                        .HasColumnType("int");

                    b.Property<int?>("ProfessionalServiceProfessionalId")
                        .HasColumnType("int");

                    b.Property<int?>("ProfessionalServiceServiceId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int>("Userid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfessionalId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("Userid");

                    b.HasIndex("ProfessionalServiceProfessionalId", "ProfessionalServiceServiceId");

                    b.ToTable("appointments");
                });

            modelBuilder.Entity("Appointments_API.Models.Professional", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("professionals");
                });

            modelBuilder.Entity("Appointments_API.Models.ProfessionalService", b =>
                {
                    b.Property<int>("ProfessionalId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("ServiceId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("ProfessionalId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("professionalServices");
                });

            modelBuilder.Entity("Appointments_API.Models.Service", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<double>("cost")
                        .HasColumnType("float");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("services");
                });

            modelBuilder.Entity("Appointments_API.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Appointments_API.Models.Appointment", b =>
                {
                    b.HasOne("Appointments_API.Models.Professional", "Professional")
                        .WithMany()
                        .HasForeignKey("ProfessionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Appointments_API.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Appointments_API.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Appointments_API.Models.ProfessionalService", null)
                        .WithMany("Appointments")
                        .HasForeignKey("ProfessionalServiceProfessionalId", "ProfessionalServiceServiceId");

                    b.Navigation("Professional");

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Appointments_API.Models.ProfessionalService", b =>
                {
                    b.HasOne("Appointments_API.Models.Professional", "Professional")
                        .WithMany("ProfessionalServices")
                        .HasForeignKey("ProfessionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Appointments_API.Models.Service", "Service")
                        .WithMany("ProfessionalServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professional");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Appointments_API.Models.Professional", b =>
                {
                    b.Navigation("ProfessionalServices");
                });

            modelBuilder.Entity("Appointments_API.Models.ProfessionalService", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Appointments_API.Models.Service", b =>
                {
                    b.Navigation("ProfessionalServices");
                });
#pragma warning restore 612, 618
        }
    }
}
