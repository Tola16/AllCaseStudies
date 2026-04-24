using Microsoft.AspNetCore.Mvc;
using Vehicle_System.Interface;
using Vehicle_System.Models;
using Vehicle_System.View_Model;

namespace Vehicle_System.Controllers
{
    public class MaintenanceRecordController : Controller
    {
        IGenericRepo<MaintenanceRecord> MRrepo;
        IGenericRepo<Vehicle> Vrepo;
        IGenericRepo<MaintenanceType> MTrepo;

        public MaintenanceRecordController(IGenericRepo<MaintenanceRecord> MRrepo, IGenericRepo<Vehicle> Vrepo , IGenericRepo<MaintenanceType> MTrepo)
        {
            this.MRrepo = MRrepo;
            this.Vrepo = Vrepo;
            this.MTrepo = MTrepo;
        }
      
        public IActionResult Index()
        {
         
            var a = MRrepo.GetAll();
            return View(a);
        }
        public IActionResult Details (int id )
        {

            var a = MRrepo.GetById(id);
            return View(a);

        }
        public IActionResult Delete (int id)
        {
             var a = MRrepo.GetById(id);
            MRrepo.Delete(a);
            MRrepo.save();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            var a = new MaintenanceRecordVm()
            {
                Vehicles = Vrepo.GetAll(),
                MaintenanceTypes = MTrepo.GetAll(),

            };
            return View(a);
        }
        [HttpPost]
        public IActionResult Create(MaintenanceRecordVm vm)
        {

            var a = new MaintenanceRecord()
            {
                 CurrentKm = vm.CurrentKm,
                  MaintenanceTypeId = vm.MaintenanceTypeId,
                   VehicleId = vm.VehicleId,
                    ServiceDate = vm.ServiceDate,
                   MaintenanceRecordId = vm.MaintenanceRecordId,
                     Notes = vm.Notes,
            };
            MRrepo.Add(a);
            MRrepo.save();
            return RedirectToAction("Index");
        }
       

    }
}
