﻿// <auto-generated />
using System;
using Booking_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Booking_System.Migrations
{
    [DbContext(typeof(BookingContext))]
    [Migration("20221225225655_pri")]
    partial class pri
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Booking_System.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Data_start")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Date_End")
                        .HasColumnType("datetime2");

                    b.Property<int>("Guet_id")
                        .HasColumnType("int");

                    b.Property<int>("Room_id")
                        .HasColumnType("int");

                    b.Property<double?>("Totalprice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Guet_id");

                    b.HasIndex("Room_id");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Booking_System.Models.Branch", b =>
                {
                    b.Property<int>("B_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("B_Id"), 1L, 1);

                    b.Property<string>("B_Loaction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("B_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("B_Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hotal_code")
                        .HasColumnType("int");

                    b.HasKey("B_Id");

                    b.HasIndex("Hotal_code");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("Booking_System.Models.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("F_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("L_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(11)
                        .HasColumnType("Char(11)");

                    b.Property<string>("pass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("Booking_System.Models.Hotal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hotal");
                });

            modelBuilder.Entity("Booking_System.Models.Room", b =>
                {
                    b.Property<int>("Room_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Room_id"), 1L, 1);

                    b.Property<int>("B_id")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("Money");

                    b.Property<string>("Room_Dec")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Room_type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Room_id");

                    b.HasIndex("B_id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Booking_System.Models.Booking", b =>
                {
                    b.HasOne("Booking_System.Models.Guest", "Guest")
                        .WithMany("Booking")
                        .HasForeignKey("Guet_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Booking_System.Models.Room", "Rooms")
                        .WithMany("Bookings")
                        .HasForeignKey("Room_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Booking_System.Models.Branch", b =>
                {
                    b.HasOne("Booking_System.Models.Hotal", "Hotal")
                        .WithMany("Branches")
                        .HasForeignKey("Hotal_code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotal");
                });

            modelBuilder.Entity("Booking_System.Models.Room", b =>
                {
                    b.HasOne("Booking_System.Models.Branch", "Branch")
                        .WithMany("Romms")
                        .HasForeignKey("B_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("Booking_System.Models.Branch", b =>
                {
                    b.Navigation("Romms");
                });

            modelBuilder.Entity("Booking_System.Models.Guest", b =>
                {
                    b.Navigation("Booking");
                });

            modelBuilder.Entity("Booking_System.Models.Hotal", b =>
                {
                    b.Navigation("Branches");
                });

            modelBuilder.Entity("Booking_System.Models.Room", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
