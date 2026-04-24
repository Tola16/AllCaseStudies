

namespace CinemaSystem.Models
{
    public class ShowTime
    {
        public int Id { get; set; }
        public DateOnly StartShow { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int HallId { get; set; }
        public Hall Hall { get; set; }
        public List<Booking> bookings { get; set; } = new List<Booking>();
    }
}
