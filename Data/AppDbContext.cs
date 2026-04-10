using CourtBookingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CourtBookingApp.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Court> Courts { get; set; }
    }
}
