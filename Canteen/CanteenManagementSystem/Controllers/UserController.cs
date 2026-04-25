using CanteenManagementSystem.Models;
using CanteenManagementSystem.Repositories.Implementaion;
using CanteenManagementSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CanteenManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly IGenericRepository<User> _userRepo;
        public UserController(IGenericRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }
        public IActionResult Index()
        {
            var users = _userRepo.GetAll();

            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            _userRepo.Add(user);
            _userRepo.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var user = _userRepo.GetById(id);

            return View(user);
        }

        public IActionResult Edit(int id)
        {
            var user = _userRepo.GetById(id);

            if (user == null)
                return NotFound();

            return View(user);  
        }
        [HttpPost]
        public IActionResult Edit(User user)
        {
            _userRepo.Update(user);
            _userRepo.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var user = _userRepo.GetById(id);

            if(user == null)
                return NotFound();

            return View(user);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _userRepo.GetById(id);

            _userRepo.Delete(user);
            _userRepo.Save();
            return RedirectToAction("Index");
        }




    }
}
