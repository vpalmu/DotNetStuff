using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.DbContexts
{
    public class CityInfoContext : DbContext
    {
        public DbSet<City> Cities { get; set; } = null!; // null forgiving operator
        public DbSet<PointOfInterest> PointsOfInterest { get; set; } = null!; // null forgiving operator

        public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City("New York City")
                {
                    Id = 1,
                    Description = "The one with big park"
                },
                new City("Antwerp")
                {
                    Id = 2,
                    Description = "The one with cathedral"
                },
                new City("Paris")
                {
                    Id = 3,
                    Description = "The one with big tower"
                }
            );

            modelBuilder.Entity<PointOfInterest>().HasData(
                new PointOfInterest("The Louvre")
                {
                    Id = 5,
                    CityId = 3,
                    Description = "Largest museum"
                },
                new PointOfInterest("Cathedral")
                {
                    Id = 1,
                    CityId = 2,
                    Description = "Gothic Cathedral"
                },
                new PointOfInterest("Central Park")
                {
                    Id = 2,
                    CityId = 1,
                    Description = "Big Park"
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
