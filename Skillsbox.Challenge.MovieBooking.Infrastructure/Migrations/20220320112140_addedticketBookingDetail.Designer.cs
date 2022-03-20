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
    [Migration("20220320112140_addedticketBookingDetail")]
    partial class addedticketBookingDetail
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("Skillsbox.Challenge.MovieBooking.Core.Entities.AgeCategoryDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AgeCategoryType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("AgeCategoryUnits")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TicketId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TotalPriceForAnAgeCategory")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("UnitPriceForAgeCategory")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AgeCategoryDetails");
                });

            modelBuilder.Entity("Skillsbox.Challenge.MovieBooking.Core.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BookedTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BookingOwnerEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MovieBookedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("MovieBookedon")
                        .HasColumnType("TEXT");

                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalBookedSeats")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Bookings");
                });

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

                    b.Property<decimal>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
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

            modelBuilder.Entity("Skillsbox.Challenge.MovieBooking.Core.Entities.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BookingId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ColumnNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RowAlphabet")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("Skillsbox.Challenge.MovieBooking.Core.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookingId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalNumberOfTicketsTobeBooked")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TotalPricePerAgeCategories")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BookingId")
                        .IsUnique();

                    b.ToTable("Tickets");
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

            modelBuilder.Entity("Skillsbox.Challenge.MovieBooking.Core.Entities.Seat", b =>
                {
                    b.HasOne("Skillsbox.Challenge.MovieBooking.Core.Entities.Booking", null)
                        .WithMany("BookedSeats")
                        .HasForeignKey("BookingId");
                });

            modelBuilder.Entity("Skillsbox.Challenge.MovieBooking.Core.Entities.Ticket", b =>
                {
                    b.HasOne("Skillsbox.Challenge.MovieBooking.Core.Entities.Booking", null)
                        .WithOne("Ticket")
                        .HasForeignKey("Skillsbox.Challenge.MovieBooking.Core.Entities.Ticket", "BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Skillsbox.Challenge.MovieBooking.Core.Entities.Booking", b =>
                {
                    b.Navigation("BookedSeats");

                    b.Navigation("Ticket")
                        .IsRequired();
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
