using CinemaSystem.Models;
using CinemaSystem.Repos.Interfaces;
using CinemaSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSystem.Controllers
{
    public class BookingController : Controller
    {
        IGenericRepo<Booking> _bookingrepo;
        IGenericRepo<User> _userrepo;
        IGenericRepo<ShowTime> _Showtimerepo;

        public BookingController(IGenericRepo<Booking> b, IGenericRepo<User> u, IGenericRepo<ShowTime> st)
        {
            _bookingrepo = b;
            _userrepo = u;
            _Showtimerepo = st;
        }

        public IActionResult Index()
        {

            var vm = _bookingrepo.GetAll();
            return View(vm);

        }
        public IActionResult Details(int id)
        {
            var booking = _bookingrepo.GetById(id);
            return View(booking);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var vm = new BookingVM
            {
                users = _userrepo.GetAll(),
                showimes = _Showtimerepo.GetAll(),
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(BookingVM bookingVm)
        {
            var vm = new Booking
            {
                BokkiingDate = bookingVm.BokkiingDate,
                Id = bookingVm.Id,
                NumberOfSeats = bookingVm.NumberOfSeats,
                ShowTimeId = bookingVm.ShowTimeId,
                UserId = bookingVm.UserId,
            };

            _bookingrepo.Add(vm);
            _bookingrepo.save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var booking = _bookingrepo.GetById(id);
            var vm = new BookingVM
            {
                BokkiingDate = booking.BokkiingDate,
                Id = booking.Id,
                NumberOfSeats = booking.NumberOfSeats,
                ShowTimeId = booking.ShowTimeId,
                UserId = booking.UserId,

            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(BookingVM bookingVm)
        {
            var vm = new Booking
            {
                BokkiingDate = bookingVm.BokkiingDate,
                Id = bookingVm.Id,
                NumberOfSeats = bookingVm.NumberOfSeats,
                ShowTimeId = bookingVm.ShowTimeId,
                UserId = bookingVm.UserId,
            };
            _bookingrepo.Add(vm);
            _bookingrepo.save();
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            var booking = _bookingrepo.GetById(id);
            _bookingrepo.Delete(booking);
            _bookingrepo.save();
            return RedirectToAction("Index");
        }
    }
}
