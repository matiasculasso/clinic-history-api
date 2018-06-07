﻿// <auto-generated />
using ClinicHistoryApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ClinicHistoryApi.Data.Migrations.Entities
{
    [DbContext(typeof(EntitiesDbContext))]
    partial class EntitiesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("entities")
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClinicHistoryApi.Entities.Complement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ConsultationId")
                        .HasColumnName("ConsultationId");

                    b.Property<DateTime>("Date");

                    b.HasKey("Id");

                    b.HasIndex("ConsultationId");

                    b.ToTable("Complement");
                });

            modelBuilder.Entity("ClinicHistoryApi.Entities.ComplementaryMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ComplementaryMethod");
                });

            modelBuilder.Entity("ClinicHistoryApi.Entities.ComplementaryMethodInstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ComplementId");

                    b.Property<int>("ComplementaryMethodId")
                        .HasColumnName("ComplementaryMethodId");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ComplementId");

                    b.HasIndex("ComplementaryMethodId");

                    b.ToTable("ComplementaryMethodInstance");
                });

            modelBuilder.Entity("ClinicHistoryApi.Entities.Consultation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alimentation")
                        .HasMaxLength(250);

                    b.Property<string>("Comments")
                        .HasMaxLength(500);

                    b.Property<bool>("ComplementaryMethodRequested");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(150);

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<DateTime>("Date");

                    b.Property<string>("DefecatoryHabit")
                        .HasMaxLength(150);

                    b.Property<string>("Evolution")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<double?>("Length");

                    b.Property<int>("PatientId")
                        .HasColumnName("PatientId");

                    b.Property<string>("PhysicalActivity")
                        .HasMaxLength(250);

                    b.Property<string>("PhysicalExam")
                        .HasMaxLength(250);

                    b.Property<string>("SchoolPerformance")
                        .HasMaxLength(250);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(150);

                    b.Property<DateTime?>("UpdatedOn");

                    b.Property<double?>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Consultation");
                });

            modelBuilder.Entity("ClinicHistoryApi.Entities.Diagnostic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Diagnostic");
                });

            modelBuilder.Entity("ClinicHistoryApi.Entities.Laboratory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Laboratory");
                });

            modelBuilder.Entity("ClinicHistoryApi.Entities.LaboratoryInstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ComplementId");

                    b.Property<int>("LaboratoryId")
                        .HasColumnName("LaboratoryId");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ComplementId");

                    b.HasIndex("LaboratoryId");

                    b.ToTable("LaboratoryInstance");
                });

            modelBuilder.Entity("ClinicHistoryApi.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("ConsultationReason")
                        .IsRequired();

                    b.Property<string>("ContactPhones")
                        .HasMaxLength(250);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(150);

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<int?>("DiagnosticId");

                    b.Property<string>("Email")
                        .HasMaxLength(250);

                    b.Property<string>("EpidemiologicalBackground");

                    b.Property<string>("FamilyBackground");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Origin")
                        .HasMaxLength(350);

                    b.Property<string>("PathologicalBackground");

                    b.Property<string>("PhysiologicalBackground");

                    b.Property<string>("PrerinatologicalBackground");

                    b.Property<int?>("SocialSecurityId");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(150);

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("DiagnosticId");

                    b.HasIndex("IdentificationNumber");

                    b.HasIndex("LastName");

                    b.HasIndex("Name");

                    b.HasIndex("SocialSecurityId");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("ClinicHistoryApi.Entities.SocialSecurity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("SocialSecurity");
                });

            modelBuilder.Entity("ClinicHistoryApi.Entities.ComplementaryMethodInstance", b =>
                {
                    b.HasOne("ClinicHistoryApi.Entities.Complement")
                        .WithMany("ComplementaryMethods")
                        .HasForeignKey("ComplementId");
                });

            modelBuilder.Entity("ClinicHistoryApi.Entities.LaboratoryInstance", b =>
                {
                    b.HasOne("ClinicHistoryApi.Entities.Complement")
                        .WithMany("LaboratoryInstances")
                        .HasForeignKey("ComplementId");
                });

            modelBuilder.Entity("ClinicHistoryApi.Entities.Patient", b =>
                {
                    b.HasOne("ClinicHistoryApi.Entities.Diagnostic", "Diagnostic")
                        .WithMany()
                        .HasForeignKey("DiagnosticId");

                    b.HasOne("ClinicHistoryApi.Entities.SocialSecurity", "SocialSecurity")
                        .WithMany()
                        .HasForeignKey("SocialSecurityId");
                });
#pragma warning restore 612, 618
        }
    }
}
