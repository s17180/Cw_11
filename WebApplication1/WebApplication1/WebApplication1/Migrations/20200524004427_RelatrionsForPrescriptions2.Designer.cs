﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Models;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ClinDbContext))]
    [Migration("20200524004427_RelatrionsForPrescriptions2")]
    partial class RelatrionsForPrescriptions2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.Medicament", b =>
                {
                    b.Property<int?>("IdMedicament")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMedicament");

                    b.ToTable("Medicaments");
                });

            modelBuilder.Entity("WebApplication1.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("WebApplication1.Models.Prescription", b =>
                {
                    b.Property<int?>("IdPrescrition")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int?>("IdClient")
                        .HasColumnType("int");

                    b.Property<int?>("IdDoctor")
                        .HasColumnType("int");

                    b.HasKey("IdPrescrition");

                    b.HasIndex("ClientId");

                    b.HasIndex("DoctorId");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("WebApplication1.Models.Client", b =>
                {
                    b.HasBaseType("WebApplication1.Models.Person");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("WebApplication1.Models.Doctor", b =>
                {
                    b.HasBaseType("WebApplication1.Models.Person");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Doctor");
                });

            modelBuilder.Entity("WebApplication1.Models.Prescription", b =>
                {
                    b.HasOne("WebApplication1.Models.Client", "Client")
                        .WithMany("Prescriptions")
                        .HasForeignKey("ClientId");

                    b.HasOne("WebApplication1.Models.Doctor", "Doctor")
                        .WithMany("Prescriptions")
                        .HasForeignKey("DoctorId");
                });
#pragma warning restore 612, 618
        }
    }
}
