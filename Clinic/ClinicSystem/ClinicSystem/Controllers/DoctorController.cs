using ClinicSystem.Models;
using ClinicSystem.Repos.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.Controllers
{
    public class DoctorController : Controller
    {
        IGenericRepo<Doctor> _doctorrepo;
        public DoctorController(IGenericRepo<Doctor> genericRepo)
        {
            _doctorrepo = genericRepo;
        }
        public IActionResult Index()
        {

            var alldoctors = _doctorrepo.GetAll();
            return View(alldoctors);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {

            _doctorrepo.Add(doctor);
            _doctorrepo.Save();
            return RedirectToAction("Index");
        } 
        public IActionResult Edit(int id)
        {
            var doctor = _doctorrepo.GetById(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }
        [HttpPost]
        public IActionResult Edit(Doctor doctor)
        {

            _doctorrepo.Update(doctor);
            _doctorrepo.Save();
            return RedirectToAction("Index");
        } 

        public IActionResult Details(int id)
        {

            var doctor = _doctorrepo.GetById(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        public IActionResult Delete(int id)
        {

            var doctor = _doctorrepo.GetById(id);
            if (doctor == null)
            {
                return NotFound();
            }
            _doctorrepo.Delete(doctor);
            _doctorrepo.Save();
            return RedirectToAction("Index");
        }

    }

}
