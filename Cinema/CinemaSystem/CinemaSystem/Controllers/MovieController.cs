using CinemaSystem.Models;
using Microsoft.EntityFrameworkCore;
using CinemaSystem.Repos.Interfaces;
using CinemaSystem.Repos.implement;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSystem.Controllers
{
    public class MovieController : Controller
    {
         IMovieRepo   _movierepo;
        public MovieController(IMovieRepo repo)
        {
            _movierepo = repo;
        }

        public IActionResult Index()
        {
            var allMovies = _movierepo.GetAll();
            return View(allMovies);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            _movierepo.Add(movie);
            _movierepo.save();

            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var Movie = _movierepo.GetById(id);
            return View(Movie);
        }
        public IActionResult Delete(int id)
        {
            var Movie = _movierepo.GetById(id);
            _movierepo.Delete(Movie);
            _movierepo.save();
            return RedirectToAction("Index");
        }
        public IActionResult Search(string Name)
        {
            var t = _movierepo.Search(Name);
            return View("Index", t);
        }

    }
}
