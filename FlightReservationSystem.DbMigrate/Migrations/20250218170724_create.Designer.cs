﻿// <auto-generated />
using System;
using FlightReservationSystem.DbMigrate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlightReservationSystem.DbMigrate.Migrations
{
    [DbContext(typeof(MigrateDbContext))]
    [Migration("20250218170724_create")]
    partial class create
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FlightReservationSystem.Model.Entity.AirlineAgency", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AirLineCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("AirlineAgency", "Flight");
                });

            modelBuilder.Entity("FlightReservationSystem.Model.Entity.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("City", "Flight");
                });

            modelBuilder.Entity("FlightReservationSystem.Model.Entity.Flight", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AircraftModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("AirlineAgency_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("ArrivalTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("CabinClassType")
                        .HasColumnType("int");

                    b.Property<int>("CargoAllowance")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreateDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DepartureTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("DestinationCity_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FlightNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FlightType")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("OriginCity_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SeatsCount")
                        .HasColumnType("int");

                    b.Property<int>("TerminalType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AirlineAgency_Id");

                    b.HasIndex("DestinationCity_Id");

                    b.HasIndex("OriginCity_Id");

                    b.ToTable("Flight", "Flight");
                });

            modelBuilder.Entity("FlightReservationSystem.Model.Entity.TicketsBooked", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreateDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("Flight_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("SeatNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("User_Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Flight_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("TicketsBooked", "Flight");
                });

            modelBuilder.Entity("FlightReservationSystem.Model.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("BirthDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("CreateDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("char(11)");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasColumnType("char(10)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("RoleType")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User", "Flight");
                });

            modelBuilder.Entity("FlightReservationSystem.Model.Entity.UserAuthentication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("ExpireDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("User_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("VerifyCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("User_Id");

                    b.ToTable("UserAuthentication", "Flight");
                });

            modelBuilder.Entity("FlightReservationSystem.Model.Entity.Flight", b =>
                {
                    b.HasOne("FlightReservationSystem.Model.Entity.AirlineAgency", "AirlineAgency")
                        .WithMany("Flight")
                        .HasForeignKey("AirlineAgency_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightReservationSystem.Model.Entity.City", "DestinationCity")
                        .WithMany("DestinationFlight")
                        .HasForeignKey("DestinationCity_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FlightReservationSystem.Model.Entity.City", "OriginCity")
                        .WithMany("OriginFlight")
                        .HasForeignKey("OriginCity_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AirlineAgency");

                    b.Navigation("DestinationCity");

                    b.Navigation("OriginCity");
                });

            modelBuilder.Entity("FlightReservationSystem.Model.Entity.TicketsBooked", b =>
                {
                    b.HasOne("FlightReservationSystem.Model.Entity.Flight", "Flight")
                        .WithMany("Bookings")
                        .HasForeignKey("Flight_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightReservationSystem.Model.Entity.User", "User")
                        .WithMany("TicketsBooked")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlightReservationSystem.Model.Entity.UserAuthentication", b =>
                {
                    b.HasOne("FlightReservationSystem.Model.Entity.User", "User")
                        .WithMany("UserAuthentication")
                        .HasForeignKey("User_Id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlightReservationSystem.Model.Entity.AirlineAgency", b =>
                {
                    b.Navigation("Flight");
                });

            modelBuilder.Entity("FlightReservationSystem.Model.Entity.City", b =>
                {
                    b.Navigation("DestinationFlight");

                    b.Navigation("OriginFlight");
                });

            modelBuilder.Entity("FlightReservationSystem.Model.Entity.Flight", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("FlightReservationSystem.Model.Entity.User", b =>
                {
                    b.Navigation("TicketsBooked");

                    b.Navigation("UserAuthentication");
                });
#pragma warning restore 612, 618
        }
    }
}
