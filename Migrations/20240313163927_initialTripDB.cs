using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Trip_log.Migrations
{
    /// <inheritdoc />
    public partial class initialTripDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Accommodation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccommodationPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccommodationEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThingToDo1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThingToDo2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThingToDo3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripId);
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "Accommodation", "AccommodationEmail", "AccommodationPhone", "Destination", "EndDate", "StartDate", "ThingToDo1", "ThingToDo2", "ThingToDo3" },
                values: new object[,]
                {
                    { 1, null, null, null, "Tokyo", new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shinjuku tours", null, null },
                    { 2, "Brother's House", "sam@gmail.com", "5479633201", "London", new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visit Tower Bridge", "Visit Big Ben", "Ride Ferris Wheel" },
                    { 3, "Friend's Apartment", "amansingh@gmail.com", "4087952136", "New York", new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Time Square", "57th Street", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
