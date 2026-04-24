using ClinicSystem.Models;
using ClinicSystem.Repos.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.Controllers
{
    public class PatientController : Controller 
    {
        IGenericRepo<Patient> _patientrepo;
        public PatientController(IGenericRepo<Patient> genericRepo)
        {
            _patientrepo = genericRepo;
        }
        public IActionResult Index()
        {

            var allpatients = _patientrepo.GetAll();
            return View(allpatients);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Patient patient)
        {

            _patientrepo.Add(patient);
            _patientrepo.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var patient = _patientrepo.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }
        [HttpPost]
        public IActionResult Edit(Patient patient   )
        {

            _patientrepo.Update(patient);
            _patientrepo.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {

            var doctor = _patientrepo.GetById(id);
            if (doctor ==null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        public IActionResult Delete(int id)
        {

            var patient = _patientrepo.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }
            _patientrepo.Delete(patient);
            _patientrepo.Save();
            return RedirectToAction("Index");
        }
    }
}
