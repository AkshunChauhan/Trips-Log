﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trip_log.Models;

#nullable disable

namespace Trip_log.Migrations
{
    [DbContext(typeof(TripContext))]
    [Migration("20240313163927_initialTripDB")]
    partial class initialTripDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Trip_log.Models.Trip", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TripId"));

                    b.Property<string>("Accommodation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccommodationEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccommodationPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ThingToDo1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThingToDo2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThingToDo3")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TripId");

                    b.ToTable("Trips");

                    b.HasData(
                        new
                        {
                            TripId = 1,
                            Destination = "Boise",
                            EndDate = new DateTime(2020, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2020, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ThingToDo1 = "Visit Tammy"
                        },
                        new
                        {
                            TripId = 2,
                            Accommodation = "The Benson Hotel",
                            AccommodationEmail = "staff@bensonhotel.com",
                            AccommodationPhone = "(503) 555-1234",
                            Destination = "Portland",
                            EndDate = new DateTime(2021, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ThingToDo1 = "Go to Voodoo Doughnuts",
                            ThingToDo2 = "Walk in the rain",
                            ThingToDo3 = "Go to Powell's"
                        },
                        new
                        {
                            TripId = 3,
                            Accommodation = "The Ritz",
                            AccommodationEmail = "contact@theritz.com",
                            AccommodationPhone = "(555) 123-4567",
                            Destination = "New York",
                            EndDate = new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2020, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ThingToDo1 = "Go to a show",
                            ThingToDo2 = "Ride the subway"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
