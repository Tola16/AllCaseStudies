using Microsoft.AspNetCore.Mvc;
using Vehicle_System.Implementation;
using Vehicle_System.Interface;
using Vehicle_System.Models;

namespace Vehicle_System.Controllers
{
    public class UserController : Controller
    {
        IGenericRepo<User> repo;
        public UserController(IGenericRepo<User> repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var a = repo.GetAll();
            return View(a);
        }

            public IActionResult Details(int id)
            {

                var a = repo.GetById(id);
                return View(a);
            }

            public IActionResult Create()
            {
               return View();
            }
        [HttpPost]
        public IActionResult Create(User user)
        {
            repo.Add(user);
            repo.save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

          var a =  repo.GetById(id);
            return View(a);
        }
        [HttpPost]
        public IActionResult Edit(User user)
        {
            repo.Update(user);
            repo.save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = repo.GetById(id);
            repo.Delete(user);
            repo.save();

            return RedirectToAction("Index");
        }

    }
}
