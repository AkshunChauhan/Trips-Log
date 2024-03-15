using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Trip_log.Models
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options)
            : base(options)
        { }

        //Table declaration
        public DbSet<Trip> Trips { get; set; }

        //Data Population
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Populates Trips Table
            modelBuilder.Entity<Trip>().HasData(
                new Trip
                {
                    TripId = 1,
                    Destination = "Tokyo",
                    StartDate = new DateTime(2022, 12, 16),
                    EndDate = new DateTime(2022, 12, 26),
                    ThingToDo1 = "Shinjuku tours"
                },
                new Trip
                {
                    TripId = 2,
                    Destination = "London",
                    StartDate = new DateTime(2024, 3, 6),
                    EndDate = new DateTime(2024, 3, 8),
                    Accommodation = "Brother's House",
                    AccommodationPhone = "5479633201",
                    AccommodationEmail = "sam@gmail.com",
                    ThingToDo1 = "Visit Tower Bridge",
                    ThingToDo2 = "Visit Big Ben",
                    ThingToDo3 = "Ride Ferris Wheel"
                },
                new Trip
                {
                    TripId = 3,
                    Destination = "New York",
                    StartDate = new DateTime(2025, 5, 25),
                    EndDate = new DateTime(2025, 6, 1),
                    Accommodation = "Friend's Apartment",
                    AccommodationPhone = "4087952136",
                    AccommodationEmail = "amansingh@gmail.com",
                    ThingToDo1 = "Time Square",
                    ThingToDo2 = "57th Street"
                });
        }
    }

    // Custom validation attribute to ensure start date is before end date
    public class StartBeforeEndDateAttribute : ValidationAttribute
    {
        private readonly string _startDatePropertyName;

        public StartBeforeEndDateAttribute(string startDatePropertyName)
        {
            _startDatePropertyName = startDatePropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var startDateProperty = validationContext.ObjectType.GetProperty(_startDatePropertyName);

            if (startDateProperty == null)
            {
                return new ValidationResult($"Unknown property {_startDatePropertyName}");
            }

            var startDateValue = (DateTime)startDateProperty.GetValue(validationContext.ObjectInstance);

            if (value == null || startDateValue == null)
            {
                return ValidationResult.Success;
            }

            DateTime startDate = (DateTime)startDateValue;
            DateTime endDate = (DateTime)value;

            if (startDate > endDate)
            {
                return new ValidationResult("End Date must be after Start Date");
            }

            return ValidationResult.Success;
        }
    }
}
