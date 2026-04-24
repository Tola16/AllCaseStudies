using Microsoft.AspNetCore.Mvc;
using Simple_Attendance_Tracking.Models;

namespace Simple_Attendance_Tracking.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubject _s;

        public SubjectController(ISubject subjectRepo)
        {
            _s = subjectRepo;
        }

        // GET: Subject
        public IActionResult Index()
        {
            var ss = _s.GetAll();
            return View(ss);
        }

        // GET: Subject/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subject/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Subject collection)
        {
            
                _s.Add(collection);
                return RedirectToAction(nameof(Index));
   
        }
    }
}