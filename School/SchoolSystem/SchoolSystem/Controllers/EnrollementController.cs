using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using SchoolSystem.Models;
using SchoolSystem.Repos.Interface;
using SchoolSystem.ViewModels;

namespace SchoolSystem.Controllers
{
    public class EnrollementController : Controller
    {
        IGenericRepo<Enrollment> _enrollementrepo;
        IGenericRepo<Course> _courserepo;
        IGenericRepo<Student> _studentrepo;

        public EnrollementController(IGenericRepo<Enrollment> e, IGenericRepo<Course> c, IGenericRepo<Student> s)
        {
            _enrollementrepo = e;
            _courserepo = c;
            _studentrepo = s;
        }

        public IActionResult Index()
        {
            var all = _enrollementrepo.GetAll();
            return View(all);

        }

        public IActionResult Details(int id)
        {

            var Enrollement = _enrollementrepo.GetById(id);
            return View(Enrollement);
        }

        public IActionResult Create()
        {

            var vm = new EnrollementVm()
            {
                Courses = _courserepo.GetAll(),
                Students = _studentrepo.GetAll(),
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(EnrollementVm enrollementVm)
        {
            var vm = new Enrollment()
            {
                Id = enrollementVm.id,

                CourseId = enrollementVm.CourseId,
                RegisterDate = enrollementVm.DateTime,
                StudentId = enrollementVm.StudentId,

            };
            _enrollementrepo.Add(vm);
            _enrollementrepo.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Edit()
        {

            var vm = new EnrollementVm()
            {
                Courses = _courserepo.GetAll(),
                Students = _studentrepo.GetAll(),
                 
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit (EnrollementVm enrollementVm)
        {
            var vm = new Enrollment()
            {
                CourseId = enrollementVm.CourseId,
                RegisterDate = enrollementVm.DateTime,
                StudentId = enrollementVm.StudentId,

            };
            _enrollementrepo.Update(vm);
            _enrollementrepo.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            var student = _enrollementrepo.GetById(id);
            _enrollementrepo.Delete(student);
            _enrollementrepo.Save();
            return RedirectToAction("Index");

        }



    }
}
