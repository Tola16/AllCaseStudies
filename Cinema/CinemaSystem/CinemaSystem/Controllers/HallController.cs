using CinemaSystem.Models;
using Microsoft.EntityFrameworkCore;
using CinemaSystem.Repos.Interfaces;
using CinemaSystem.Repos.implement;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSystem.Controllers
{
    public class HallController : Controller
    {
        IGenericRepo<Hall> _hallrepo;
        public HallController(IGenericRepo<Hall> repo)
        {
          _hallrepo = repo;    
        }

        public IActionResult Index ()
        {
            var allhall = _hallrepo.GetAll();
            return View(allhall);
        }

        public IActionResult Details (int id)
        {
            var hall = _hallrepo.GetById(id);
            return View(hall);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Create(Hall hall)
        {
            _hallrepo.Add(hall);
            _hallrepo.save();
            return RedirectToAction("Index");
        } 

        public IActionResult Delete(int id)
        {
            var hall = _hallrepo.GetById(id);
            _hallrepo.Delete(hall);
            _hallrepo.save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var hall = _hallrepo.GetById(id);
            return View (hall);
        }
        [HttpPost]
        public IActionResult Edit(Hall hall)
        {
            _hallrepo.Update(hall);
            _hallrepo.save();
            return RedirectToAction("Index");
        }

        


    }
}
