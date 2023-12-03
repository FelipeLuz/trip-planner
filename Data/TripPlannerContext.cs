using Microsoft.EntityFrameworkCore;
using trip_planner.Models;

public class TripPlannerContext : DbContext
{
    public TripPlannerContext(DbContextOptions<TripPlannerContext> options) : base(options){}

    public DbSet<Accommodation> Accommodations { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<User> Users { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data for Accommodations
        modelBuilder.Entity<Accommodation>().HasData(
            new Accommodation { AccommodationID = 1, Name = "Sea View Hotel", Location = "Ocean Drive", Type = "Hotel", PricePerNight = 100.50f, Description = "Beautiful sea view and luxurious rooms." },
            new Accommodation { AccommodationID = 2, Name = "Mountain Lodge", Location = "Hilltop Road", Type = "Inn", PricePerNight = 80.00f, Description = "Cozy lodge in the mountains." }
        );

        // Seed data for Activities
        modelBuilder.Entity<Activity>().HasData(
            new Activity { ActivityID = 1, Name = "City Tour", Type = "Tour", Location = "Downtown", Price = 20.00f, Description = "Guided city tour around the main attractions." },
            new Activity { ActivityID = 2, Name = "Gourmet Dining", Type = "Restaurant", Location = "Central Plaza", Price = 50.00f, Description = "Fine dining experience in the city center." }
        );

        // Seed data for Users
        modelBuilder.Entity<User>().HasData(
            new User { UserID = 1, Name = "John Doe", Email = "johndoe@example.com", Password = "password123", Description = "Frequent traveler." },
            new User { UserID = 2, Name = "Jane Smith", Email = "janesmith@example.com", Password = "securepassword", Description = "Loves luxury travel and fine dining." }
        );
    }
}
