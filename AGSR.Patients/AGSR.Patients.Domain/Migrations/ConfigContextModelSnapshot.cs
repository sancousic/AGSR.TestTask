﻿// <auto-generated />
using System;
using AGSR.Patients.Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AGSR.Patients.Domain.Migrations
{
    [DbContext(typeof(ConfigContext))]
    partial class ConfigContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AGSR.Patients.Domain.Entities.GivenName", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("NameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NameId");

                    b.ToTable("GivenNames");
                });

            modelBuilder.Entity("AGSR.Patients.Domain.Entities.Name", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Use")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Names");
                });

            modelBuilder.Entity("AGSR.Patients.Domain.Entities.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Active")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("BirthDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("AGSR.Patients.Domain.Entities.GivenName", b =>
                {
                    b.HasOne("AGSR.Patients.Domain.Entities.Name", "Name")
                        .WithMany("GivenNames")
                        .HasForeignKey("NameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Name");
                });

            modelBuilder.Entity("AGSR.Patients.Domain.Entities.Name", b =>
                {
                    b.HasOne("AGSR.Patients.Domain.Entities.Patient", "Patient")
                        .WithOne("Name")
                        .HasForeignKey("AGSR.Patients.Domain.Entities.Name", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("AGSR.Patients.Domain.Entities.Name", b =>
                {
                    b.Navigation("GivenNames");
                });

            modelBuilder.Entity("AGSR.Patients.Domain.Entities.Patient", b =>
                {
                    b.Navigation("Name");
                });
#pragma warning restore 612, 618
        }
    }
}
