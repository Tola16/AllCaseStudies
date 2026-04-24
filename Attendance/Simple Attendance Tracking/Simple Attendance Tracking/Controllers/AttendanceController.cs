using Microsoft.AspNetCore.Mvc;
using Simple_Attendance_Tracking.Models;

namespace Simple_Attendance_Tracking.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IAttendance _attendanceRepo;
        private readonly IStudent _studentRepo;
        private readonly ISubject _subjectRepo;

        public AttendanceController(IAttendance attendanceRepo, IStudent studentRepo, ISubject subjectRepo)
        {
            _attendanceRepo = attendanceRepo;
            _studentRepo = studentRepo;
            _subjectRepo = subjectRepo;
        }

        // GET: Index
        public ActionResult Index()
        {
            var a = _attendanceRepo.GetAll();
            return View(a);
        }

        // GET: Create
        public ActionResult Create()
        {
            var adat = new VM
            {
                Students = _studentRepo.GetAll(), 
                Subjects = _subjectRepo.GetAll(), 
            };
            return View(adat);
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VM collection)
        {
           
                _attendanceRepo.Add(collection); 
                return RedirectToAction(nameof(Index));
      
        }

        public ActionResult Edit(int id)
        {
            var a = _attendanceRepo.GetById(id);
            if (a == null) return NotFound();

            var adat = new VM
            {
                Id = a.Id,
                StudentId = a.StudentId,
                SubjectId = a.SubjectId,
                Status = a.Status,
                Students = _studentRepo.GetAll(),
                Subjects = _subjectRepo.GetAll(),
            };
            return View(adat);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, VM collection)
        {
            if (id != collection.Id) return NotFound();

            _attendanceRepo.Update(collection); 
            return RedirectToAction(nameof(Index));
        }

        // GET: Delete
        public IActionResult Delete(int id)
        {
            var a = _attendanceRepo.GetById(id);
            if (a == null) return NotFound();

            var modelForView = new VM
            {
                Id = a.Id,
                Status = a.Status,
                Student = a.Student,
                Subject = a.Subject
            };

            return View(modelForView);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _attendanceRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}