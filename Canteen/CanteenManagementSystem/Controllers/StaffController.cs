using CanteenManagementSystem.Models;
using CanteenManagementSystem.Repositories.Interfaces;
using CanteenManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.CodeDom;

namespace CanteenManagementSystem.Controllers
{
    public class StaffController : Controller
    {
        private readonly IGenericRepository<Staff> _staffRepo;
        private readonly IGenericRepository<User> _userRepo;
        private readonly IGenericRepository<Order> _orderRepo;


        public StaffController(IGenericRepository<Staff> repository, IGenericRepository<User> repo, IGenericRepository<Order> orderRepo)
        {
            _staffRepo = repository;
            _userRepo = repo;
            _orderRepo = orderRepo;
        }
        public IActionResult Index()
        {
            var staffs = _staffRepo.GetAll();

            return View(staffs);
        }

        public IActionResult Create()
        {
            var vm = new CreateStaffViewModel()
            {
                Users = _userRepo.GetAll(),
            };

            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(CreateStaffViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var Staff = new Staff()
            {
                Name = vm.Name,
                PhoneNumber = vm.PhoneNumber,
                JonTitle = vm.JonTitle,
                UserId = vm.CreatedByUserId,
                Status = vm.Status
            };
            _staffRepo.Add(Staff);
            _staffRepo.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var staff = _staffRepo.GetById(id);

            if (staff == null)
                return NotFound();

            return View(staff);
        }

        public IActionResult Edit(int id)
        {
            var staff = _staffRepo.GetById(id);
            if (staff == null)
                return NotFound();

            var vm = new CreateStaffViewModel()
            {
                Name = staff.Name,
                PhoneNumber = staff.PhoneNumber,
                JonTitle = staff.JonTitle,
                Status = staff.Status,
                CreatedByUserId = staff.UserId,
                Users = _userRepo.GetAll(),
            };

            return View(vm);

        }
        [HttpPost]
        public IActionResult Edit(int id, CreateStaffViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Users = _userRepo.GetAll();
                return View(vm);
            }

            var staff = _staffRepo.GetById(id);
            if (staff == null)
                return NotFound();

            staff.Name = vm.Name;
            staff.PhoneNumber = vm.PhoneNumber;
            staff.Status = vm.Status;
            staff.JonTitle = vm.JonTitle;
            staff.UserId = vm.CreatedByUserId;
            _staffRepo.Update(staff);
            _staffRepo.Save();

            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            var staff = _staffRepo.GetById(id);

            if (staff == null)
                return NotFound();

            return View(staff);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var staff = _staffRepo.GetById(id);
            if(staff == null)
                return NotFound();

            _staffRepo.Delete(staff);
            _staffRepo.Save();

            return RedirectToAction("Index");
        }
    }
}
