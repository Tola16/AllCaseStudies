using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simple_Attendance_Tracking.Models;

namespace Simple_Attendance_Tracking.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent s;

        public StudentController(IStudent studentRepo)
        {
            s= studentRepo;
        }
        // GET: StudentController
        public IActionResult Index()
        {
            var ss = s.GetAll();

            return View(ss);
        }


        // GET: StudentController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student collection)
        {
            s.Add(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: StudentController/Edit/5
        public IActionResult Edit(int id)
        {
            var student = s.GetById(id);
            if (student == null) return NotFound();
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student collection)
        {
            s.Update(collection);
            return RedirectToAction(nameof(Index));
        }

        // GET: StudentController/Delete/5
        public IActionResult Delete(int id)
        {
            var ss = s.GetById(id);
            if (ss == null)
            {
                return NotFound();
            }
             
            return View(s);
        }



        // POST: StudentController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete2(int id)
        {
            s.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}