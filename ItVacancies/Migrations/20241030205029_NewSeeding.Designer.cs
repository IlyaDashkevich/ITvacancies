﻿// <auto-generated />
using System;
using ItVacancies.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ItVacancies.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241030205029_NewSeeding")]
    partial class NewSeeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("ItVacancies.Models.Applicant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Contacts")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("ItVacancies.Models.Base.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ResumeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("ItVacancies.Models.Employer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Contacts")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Employers");
                });

            modelBuilder.Entity("ItVacancies.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProgrammingLanguage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Skills")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Wage")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmployerId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("ItVacancies.Models.Resume", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApplicantId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Experience")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Skills")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.ToTable("Resumes");
                });

            modelBuilder.Entity("JobResume", b =>
                {
                    b.Property<int>("JobsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ResumesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("JobsId", "ResumesId");

                    b.HasIndex("ResumesId");

                    b.ToTable("JobResume");
                });

            modelBuilder.Entity("ItVacancies.Models.Base.File", b =>
                {
                    b.HasOne("ItVacancies.Models.Resume", "Resume")
                        .WithMany("Files")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("ItVacancies.Models.Job", b =>
                {
                    b.HasOne("ItVacancies.Models.Employer", "Employer")
                        .WithMany("Jobs")
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employer");
                });

            modelBuilder.Entity("ItVacancies.Models.Resume", b =>
                {
                    b.HasOne("ItVacancies.Models.Applicant", "Applicant")
                        .WithMany("Resumes")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("JobResume", b =>
                {
                    b.HasOne("ItVacancies.Models.Job", null)
                        .WithMany()
                        .HasForeignKey("JobsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ItVacancies.Models.Resume", null)
                        .WithMany()
                        .HasForeignKey("ResumesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ItVacancies.Models.Applicant", b =>
                {
                    b.Navigation("Resumes");
                });

            modelBuilder.Entity("ItVacancies.Models.Employer", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("ItVacancies.Models.Resume", b =>
                {
                    b.Navigation("Files");
                });
#pragma warning restore 612, 618
        }
    }
}