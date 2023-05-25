using Microsoft.EntityFrameworkCore;
namespace Booking_System.Models
{
    public class BookingContext:DbContext
    {
        public BookingContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }    
        public virtual DbSet<Branch> Branches { get; set; }


    }
}
