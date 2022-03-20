﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Skillsbox.Challenge.MovieBooking.Infrastructure;

#nullable disable

namespace Skillsbox.Challenge.MovieBooking.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220311133040_AddedMovieBooKingMovies")]
    partial class AddedMovieBooKingMovies
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("Skillsbox.Challenge.MovieBooking.Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Skillsbox.Challenge.MovieBooking.Core.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cast")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("RunningTimeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RunningTimeId")
                        .IsUnique();

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Skillsbox.Challenge.MovieBooking.Core.Entities.RunningDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RunningTimeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RunningTimeId");

                    b.ToTable("RunningDays");
                });

            modelBuilder.Entity("Skillsbox.Challenge.MovieBooking.Core.Entities.RunningHourAndMinute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RunningDayId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RunningDayId");

                    b.ToTable("RunningHourAndMinutes");
                });

            modelBuilder.Entity("Skillsbox.Challenge.MovieBooking.Core.Entities.RunningTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("RunningTimes");
                });

            modelBuilder.Entity("Skillsbox.Challenge.MovieBooking.Core.Entities.Movie", b =>
                {
                    b.HasOne("Skillsbox.Challenge.MovieBooking.Core.Entities.RunningTime", "RunningTime")
                        .WithOne("Movie")
                        .HasForeignKey("Skillsbox.Challenge.MovieBooking.Core.Entities.Movie", "RunningTimeId");

                    b.Navigation("RunningTime");
                });

            modelBuilder.Entity("Skillsbox.Challenge.MovieBooking.Core.Entities.RunningDay", b =>
                {
                    b.HasOne("Skillsbox.Challenge.MovieBooking.Core.Entities.RunningTime", null)
                        .WithMany("RunningDays")
                        .HasForeignKey("RunningTimeId");
                });

            modelBuilder.Entity("Skillsbox.Challenge.MovieBooking.Core.Entities.RunningHourAndMinute", b =>
                {
                    b.HasOne("Skillsbox.Challenge.MovieBooking.Core.Entities.RunningDay", null)
                        .WithMany("RunningHourAndMinutes")
                        .HasForeignKey("RunningDayId");
                });

            modelBuilder.Entity("Skillsbox.Challenge.MovieBooking.Core.Entities.RunningDay", b =>
                {
                    b.Navigation("RunningHourAndMinutes");
                });

            modelBuilder.Entity("Skillsbox.Challenge.MovieBooking.Core.Entities.RunningTime", b =>
                {
                    b.Navigation("Movie")
                        .IsRequired();

                    b.Navigation("RunningDays");
                });
#pragma warning restore 612, 618
        }
    }
}
