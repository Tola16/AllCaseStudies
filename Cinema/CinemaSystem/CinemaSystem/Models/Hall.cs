using System.ComponentModel.DataAnnotations;

namespace CinemaSystem.Models
{
    public class Hall
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<ShowTime> showTimes { get; set; } = new List<ShowTime>();
    }
}
