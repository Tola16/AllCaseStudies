using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Vehicle_System.Interface;
using Vehicle_System.Models;
using Vehicle_System.View_Model;

namespace Vehicle_System.Controllers
{
    public class VehicleController : Controller
    {
        IGenericRepo<Vehicle> Vrepo;
        IGenericRepo<User> Urepo;
        public VehicleController(IGenericRepo<Vehicle> Vrepo, IGenericRepo<User> Urepo)
        {
            this.Vrepo = Vrepo;
            this.Urepo = Urepo;
        }

        public IActionResult Index()
        {
            var vehicles = Vrepo.GetAll(); 

            return View(vehicles);
        }
        public IActionResult Details(int id)
        {

            var a  =Vrepo.GetById(id);
            return View(a);
        }

        public IActionResult Delete(int id)
        {
            var a = Vrepo.GetById(id);
               Vrepo.Delete(a);
               Vrepo.save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            var vm = new VehicleVm()
            {
                users = Urepo.GetAll()
            }; 
            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(VehicleVm vm)
        {
            
                var vehicle = new Vehicle
                {
                     Brand = vm.Brand,  
                      PlateNumber = vm.plateNumber,
                       Model = vm.model,
                        Year = vm.year,
                         UserId = vm.UserId
                };
                Vrepo.Add(vehicle);
                Vrepo.save();
           
                return RedirectToAction("Index");
            
        }

        public IActionResult Edit (int id)
        {
            var a = Vrepo.GetById(id);
            var vm = new VehicleVm
            {
                VehicleId = a.VehicleId,
                Brand = a.Brand,
                model = a.Model,
                plateNumber = a.PlateNumber,
                year = a.Year,
                UserId = a.UserId,
                users = Urepo.GetAll()
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(VehicleVm vm)
        {

            var vehicle = new Vehicle
            {
                VehicleId = vm.VehicleId,
                Brand = vm.Brand,
                Model = vm.model,
                 PlateNumber= vm.plateNumber,
                Year = vm.year,
                UserId = vm.UserId
            };
            Vrepo.Update(vehicle);
            Vrepo.save();
            return RedirectToAction("Index");
        }       


    }
}
