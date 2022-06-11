using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace BookMyShowTask.Models
{
    public class BookMyShowContext : IdentityDbContext
    {
        public BookMyShowContext()
        {
        }

        public BookMyShowContext(DbContextOptions options) : base(options) { }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Cinema> Cinema { get; set; }
        public DbSet<CinemaHall> CinemaHall { get; set; }
        public DbSet<CinemaSeat> CinemaSeat { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Seat> Seat { get; set; }
        public DbSet<Show> Show { get; set; }
        public DbSet<UserDetail> UserDetail { get; set; }

    }
}
