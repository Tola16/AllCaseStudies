using System.ComponentModel.DataAnnotations;

namespace CinemaSystem.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public int RealeseYear { get; set; }
        public List<ShowTime> ShowTime { get; set; } = new List<ShowTime>();

    }
}
