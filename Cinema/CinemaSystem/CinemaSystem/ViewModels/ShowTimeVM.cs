using CinemaSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaSystem.ViewModels
{
    public class ShowTimeVM
    {
        public int Id { get; set; }
        public DateOnly StartShow { get; set; }

        [NotMapped]
        public List<Hall> halls { get; set; }  = new List<Hall>();
        public int HallId { get; set; }
        public Hall Hall { get; set; }

        [NotMapped]
        public List<Movie> movies { get; set; } = new List<Movie>();
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
           
    }
}
