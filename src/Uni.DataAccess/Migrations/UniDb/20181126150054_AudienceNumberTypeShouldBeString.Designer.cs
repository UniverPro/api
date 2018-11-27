﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Uni.DataAccess.Contexts;

namespace Uni.DataAccess.Migrations.UniDb
{
    [DbContext(typeof(UniDbContext))]
    [Migration("20181126150054_AudienceNumberTypeShouldBeString")]
    partial class AudienceNumberTypeShouldBeString
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Uni.DataAccess.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("ShortName")
                        .HasMaxLength(50);

                    b.Property<int>("UniversityId");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.HasIndex("UniversityId");

                    b.ToTable("Faculty");
                });

            modelBuilder.Entity("Uni.DataAccess.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseNumber");

                    b.Property<int>("FacultyId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.HasIndex("Name");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("Uni.DataAccess.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AvatarPath");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("MiddleName")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("Uni.DataAccess.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AudienceNumber");

                    b.Property<TimeSpan>("Duration");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime");

                    b.Property<int>("SubjectId");

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("Uni.DataAccess.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("ScheduleId");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("Name");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("Uni.DataAccess.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("ShortName")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("University");
                });

            modelBuilder.Entity("Uni.DataAccess.Models.Student", b =>
                {
                    b.HasBaseType("Uni.DataAccess.Models.Person");

                    b.Property<int>("GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("Student");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("Uni.DataAccess.Models.Teacher", b =>
                {
                    b.HasBaseType("Uni.DataAccess.Models.Person");

                    b.Property<int>("FacultyId");

                    b.HasIndex("FacultyId");

                    b.ToTable("Teacher");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("Uni.DataAccess.Models.Faculty", b =>
                {
                    b.HasOne("Uni.DataAccess.Models.University", "University")
                        .WithMany("Faculties")
                        .HasForeignKey("UniversityId")
                        .HasConstraintName("FK_Faculty_University");
                });

            modelBuilder.Entity("Uni.DataAccess.Models.Group", b =>
                {
                    b.HasOne("Uni.DataAccess.Models.Faculty", "Faculty")
                        .WithMany("Groups")
                        .HasForeignKey("FacultyId")
                        .HasConstraintName("FK_Group_Faculty");
                });

            modelBuilder.Entity("Uni.DataAccess.Models.Schedule", b =>
                {
                    b.HasOne("Uni.DataAccess.Models.Subject", "Subject")
                        .WithOne("Schedule")
                        .HasForeignKey("Uni.DataAccess.Models.Schedule", "Id")
                        .HasConstraintName("FK_Schedule_Subject");

                    b.HasOne("Uni.DataAccess.Models.Teacher", "Teacher")
                        .WithMany("Schedules")
                        .HasForeignKey("TeacherId")
                        .HasConstraintName("FK_Subject_Teacher");
                });

            modelBuilder.Entity("Uni.DataAccess.Models.Subject", b =>
                {
                    b.HasOne("Uni.DataAccess.Models.Group", "Group")
                        .WithMany("Subjects")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_Subject_Group");
                });

            modelBuilder.Entity("Uni.DataAccess.Models.Student", b =>
                {
                    b.HasOne("Uni.DataAccess.Models.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_Person_Group")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Uni.DataAccess.Models.Teacher", b =>
                {
                    b.HasOne("Uni.DataAccess.Models.Faculty", "Faculty")
                        .WithMany("Teachers")
                        .HasForeignKey("FacultyId")
                        .HasConstraintName("FK_Person_Faculty")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
