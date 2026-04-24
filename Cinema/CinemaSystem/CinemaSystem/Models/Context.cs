using Microsoft.EntityFrameworkCore;

namespace CinemaSystem.Models

{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> op):base(op) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ShowTime> showTimes { get; set; }
        public DbSet<Hall> halls { get; set; }
        public DbSet<Booking> bookings { get; set; }





    }
}
