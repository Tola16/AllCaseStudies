using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SchoolSystem.Models;
using SchoolSystem.Repos.Interface;

namespace SchoolSystem.Controllers
{
    public class StudentController : Controller
    {
        IGenericRepo<Student> _studentrepo;
        public StudentController(IGenericRepo<Student> s)
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
        public IActionResult Create(Student student)
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
        public IActionResult Edit(Student student)
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
