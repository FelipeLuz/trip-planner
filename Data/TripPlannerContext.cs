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
    }
}
