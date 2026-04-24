
using CinemaSystem.Models;
namespace CinemaSystem.ViewModels
{
    public class BookingVM
    {

        public int Id { get; set; }
        public DateOnly BokkiingDate { get; set; }
        public int NumberOfSeats { get; set; }

        public List<User> users {  get; set; } = new List<User>();
        public int UserId { get; set; }
        public User User { get; set; }



        public List<ShowTime> showimes { get; set; } = new List<ShowTime>();
        public int ShowTimeId { get; set; }
        public ShowTime ShowTime    { get; set; }


        public List<Booking> bb { get; set; } = new List<Booking>();
    }
}
