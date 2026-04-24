using ClinicSystem.Models;
using ClinicSystem.Repos.Interface;
using ClinicSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace ClinicSystem.Controllers
{
    public class AppointmentController : Controller
    {
        IGenericRepo<Appointment> _appointmentrepo;
        IGenericRepo<Doctor> _doctorrepo;
        IGenericRepo<Patient> _patientrepo;

        public AppointmentController(IGenericRepo<Appointment> appointmentrepo, IGenericRepo<Doctor> doctorrepo, IGenericRepo<Patient> patientrepo)
        {
            _appointmentrepo = appointmentrepo;
            _doctorrepo = doctorrepo;
            _patientrepo = patientrepo;
        }

        public IActionResult Index()
        {

            var allappointments = _appointmentrepo.GetAll();
            return View(allappointments);

        }
        public IActionResult Details(int id)
        {

            var appointment = _appointmentrepo.GetById(id);
            return View(appointment);
        }

        public IActionResult Delete(int id)
        {
            var appointment = _appointmentrepo.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            _appointmentrepo.Delete(appointment);
            _appointmentrepo.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {

            var vm = new AppointmentVm()
            {
                doctors = _doctorrepo.GetAll().ToList(),
                patients = _patientrepo.GetAll().ToList()
            };

            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(AppointmentVm appointmentVm)
        {
            var appointment = new Appointment()
            {
                AppointmentId = appointmentVm.AppointmentId,
                DoctorID = appointmentVm.DocId,
                PatientID = appointmentVm.PatId,
                 Notes = appointmentVm.Notes,
                  Date = appointmentVm.Date
            };
            _appointmentrepo.Add(appointment);
            _appointmentrepo.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Edit()
        {

            var vm = new AppointmentVm()
            {
                doctors = _doctorrepo.GetAll().ToList(),
                patients = _patientrepo.GetAll().ToList(),
            };

            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(AppointmentVm appointmentVm)
        {
            var appointment = new Appointment()
            {
                AppointmentId = appointmentVm.AppointmentId,
                DoctorID = appointmentVm.DocId,
                PatientID = appointmentVm.PatId,
                Notes = appointmentVm.Notes,
                Date = appointmentVm.Date
            };
            _appointmentrepo.Update(appointment);
            _appointmentrepo.Save();
            return RedirectToAction("Index");
        }


    }
}
