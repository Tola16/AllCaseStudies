using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Vehicle_System.Interface;
using Vehicle_System.Models;
namespace Vehicle_System.Controllers
{
    public class MaintenanceTypeController : Controller
    {
        IGenericRepo<MaintenanceType> Mrepo { get; set; }
        public MaintenanceTypeController(IGenericRepo<MaintenanceType> mrepo)
        {
            Mrepo = mrepo;
        }
        public IActionResult Index()
        {

            var a = Mrepo.GetAll();
            return View(a);
        }
        public IActionResult Details(int id)
        {

            var a = Mrepo.GetById(id);
            return View(a);
        }
        public IActionResult Create(int id)
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(MaintenanceType maintenanceType)
        {

            Mrepo.Add(maintenanceType);
            Mrepo.save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var a = Mrepo.GetById(id);
            return View(a);
        }
        [HttpPost]
        public IActionResult Edit(MaintenanceType maintenanceType)
        {
            Mrepo.Update(maintenanceType);
            Mrepo.save();
            return RedirectToAction("Index");
        }

    }
}
