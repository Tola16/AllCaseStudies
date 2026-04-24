using CinemaSystem.Models;
using Microsoft.EntityFrameworkCore;
using CinemaSystem.Repos.Interfaces;
using CinemaSystem.Repos.implement;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSystem.Controllers
{

    public class UserController : Controller
    {
        IGenericRepo<User> _userrepo;
        public UserController(IGenericRepo<User> repo)
        {
              _userrepo = repo;
        }
        public IActionResult Index()
        {
            var allusers = _userrepo.GetAll();
             return View(allusers);
        }
        public IActionResult Details(int id )
        {
            var user = _userrepo.GetById(id);
            return View(user);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            _userrepo.Add(user);
            _userrepo.save();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var user = _userrepo.GetById(id);
            return View (user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
             _userrepo.Update(user);
            _userrepo.save(); 
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var user = _userrepo.GetById(id);
            _userrepo.Delete(user);
            _userrepo.save(); 
            return RedirectToAction("Index");
        }

    }
}
