using CanteenManagementSystem.Models;
using CanteenManagementSystem.Repositories.Interfaces;
using CanteenManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;

namespace CanteenManagementSystem.Controllers
{
    public class OrderController : Controller
    {
        private readonly IGenericRepository<FoodItem> _foodItemRepo;
        private readonly IGenericRepository<User> _userRepo;
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<Staff> _staffRepo;

        public OrderController(IGenericRepository<FoodItem> foodItemRepo, IGenericRepository<User> userRepo, IGenericRepository<Order> orderRepo, IGenericRepository<Staff> staffRepo)
        {
            _foodItemRepo = foodItemRepo;
            _userRepo = userRepo;
            _orderRepo = orderRepo;
            _staffRepo = staffRepo;
        }
        public IActionResult Index()
        {
            var orders = _orderRepo.GetAll();
            return View(orders);
        }

        public IActionResult Create()
        {
            var vm = new OrderViewModel()
            {
                Customers = _userRepo.GetAll().Where(u => u.Role == "Customer").ToList(),
                FoodItems = _foodItemRepo.GetAll(),
                Staff = _staffRepo.GetAll().Where(s => s.Status == "Available").ToList(),
                OrderDateTime = DateTime.Now,
            };

            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(OrderViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var order = new Order()
            {
                FoodItemId = vm.FoodItemId,
                UserId = vm.CustomerId,
                TotalPrice = _foodItemRepo.GetById(vm.FoodItemId).Price,
                StaffId = vm.StaffId,
                Status = vm.Status,
                OrderDateTime = vm.OrderDateTime,
            };
            var staff = _staffRepo.GetById(order.StaffId);

            _orderRepo.Add(order);
            _orderRepo.Save();

            staff.Status = AssignAvailability(staff.StaffId);
            _staffRepo.Update(staff);
            _staffRepo.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var order = _orderRepo.GetById(id);

            if (order == null)
                return NotFound();

            return View(order);
        }

        public IActionResult Edit(int id)
        {
            var order = _orderRepo.GetById(id);
            if (order == null)
                return NotFound();

            var vm = new OrderViewModel()
            {
                Customers = _userRepo.GetAll().Where(u => u.Role == "Customer").ToList(),
                FoodItems = _foodItemRepo.GetAll(),
                OrderDateTime = order.OrderDateTime,
                TotalPrice = order.TotalPrice,
                CustomerId = order.UserId,
                StaffId = order.StaffId,
                Status = order.Status,
                FoodItemId = order.FoodItemId,
                Staff = _staffRepo.GetAll().Where(s=>s.Status == "Available" || s.StaffId == order.StaffId).ToList(),
            };

            return View(vm);

        }
        [HttpPost]
        public IActionResult Edit(int id, OrderViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Customers = _userRepo.GetAll().Where(u => u.Role == "Customer").ToList();
                vm.FoodItems = _foodItemRepo.GetAll();
                return View(vm);
            }

            var order = _orderRepo.GetById(id);
            if (order == null)
                return NotFound();

            order.Status = vm.Status;
            order.TotalPrice = _foodItemRepo.GetById(vm.FoodItemId).Price;
            order.UserId = vm.CustomerId;
            order.FoodItemId = vm.FoodItemId;
            order.OrderDateTime = vm.OrderDateTime;

            var staff = _staffRepo.GetById(order.StaffId);

            _orderRepo.Update(order);
            _orderRepo.Save();

            staff.Status = AssignAvailability(staff.StaffId);

            _staffRepo.Update(staff);
            _staffRepo.Save();

            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            var order = _orderRepo.GetById(id);

            if (order == null)
                return NotFound();

            return View(order);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = _orderRepo.GetById(id);
            if (order == null)
                return NotFound();

            _orderRepo.Delete(order);
            _orderRepo.Save();

            return RedirectToAction("Index");
        }

        private bool CheckAvailability(int id)
        {
            var staffOrders = _staffRepo.GetById(id).Orders;
            foreach (var order in staffOrders)
            {
                if (order.Status == "Preparing")
                    return false;
            }
            return true;
        }

        private string AssignAvailability(int id)
        {
            var isAvailable = CheckAvailability(id);

            return isAvailable switch
            {
                true => "Available",
                false => "Busy"
            };
        }
    }
}
