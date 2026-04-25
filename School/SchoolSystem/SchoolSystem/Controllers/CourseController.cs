using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Models;
using SchoolSystem.Repos.Interface;

namespace SchoolSystem.Controllers
{
    public class CourseController : Controller
    {
        IGenericRepo<Course> _studentrepo;
        public CourseController(IGenericRepo<Course> s)
        {
            _studentrepo = s;
        }

        public IActionResult Index()
        {

            var allstudents = _studentrepo.GetAll();
            return View(allstudents);
        }

        public IActionResult Details(int id)
        {

            var student = _studentrepo.GetById(id);
            return View(student);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course student)
        {

            _studentrepo.Add(student);
            _studentrepo.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var student = _studentrepo.GetById(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Course student)
        {

            _studentrepo.Update(student);
            _studentrepo.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            var student = _studentrepo.GetById(id);
            _studentrepo.Delete(student);
            _studentrepo.Save();
            return RedirectToAction("Index");

        }
    }
}
