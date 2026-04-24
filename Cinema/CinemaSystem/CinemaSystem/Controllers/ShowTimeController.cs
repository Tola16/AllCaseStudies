using CinemaSystem.Models;
using Microsoft.EntityFrameworkCore;
using CinemaSystem.Repos.Interfaces;
using CinemaSystem.Repos.implement;
using CinemaSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSystem.Controllers
{
    public class ShowTimeController : Controller
    {
        //movie hall  
        IGenericRepo<Movie> _movierepo;
        IGenericRepo<Hall> _hallrepo;
        IGenericRepo<ShowTime> _showtime;

        public ShowTimeController(IGenericRepo<Movie> m, IGenericRepo<Hall> h, IGenericRepo<ShowTime> st)
        {
            _movierepo = m;
            _hallrepo = h;
            _showtime = st;
        }
        public IActionResult Index()
        {
            var allShowTimes = _showtime.GetAll();
            return View(allShowTimes);
        }

        public IActionResult Details(int id)
        {
            var Showtime = _showtime.GetById(id);
            return View(Showtime);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var vm = new ShowTimeVM
            {
                halls = _hallrepo.GetAll(),
                movies = _movierepo.GetAll(),
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(ShowTimeVM showTimeVM)
        {
            var vm = new ShowTime()
            {
                Id = showTimeVM.Id,
                HallId = showTimeVM.HallId,
                MovieId = showTimeVM.MovieId,
                StartShow = showTimeVM.StartShow,

            };
            _showtime.Add(vm);
            _showtime.save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id )
        {
            var showTimeVM  = _showtime.GetById(id);
            var vm = new ShowTimeVM()
            {
                Id = showTimeVM.Id,   
                HallId = showTimeVM.HallId,
                MovieId = showTimeVM.MovieId,
                StartShow = showTimeVM.StartShow,
                halls = _hallrepo.GetAll(),
                movies = _movierepo.GetAll(),
            };

            return View (vm); 

        }

        [HttpPost]
        public IActionResult Edit(ShowTimeVM showTimeVM)
        {
            var entity = new ShowTime()
            {
                Id = showTimeVM.Id,   
                HallId = showTimeVM.HallId,
                MovieId = showTimeVM.MovieId,
                StartShow = showTimeVM.StartShow,
            };

            _showtime.Update(entity);
            _showtime.save();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var showTimeVM = _showtime.GetById(id);
            _showtime.Delete(showTimeVM);
            _showtime.save(); 
            return RedirectToAction("Index");
        }




    }
}
