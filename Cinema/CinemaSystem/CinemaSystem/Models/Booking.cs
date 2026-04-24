using System.ComponentModel.DataAnnotations;

namespace CinemaSystem.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public DateOnly BokkiingDate { get; set; }
        public int NumberOfSeats { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ShowTime ShowTime { get; set; }
        public int ShowTimeId { get; set; }
    }
}
