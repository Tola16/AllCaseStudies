using ECommerce.Models;
using ECommerce.Repositories.Interfaces;
using ECommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class OrderController : Controller
    {
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<Customer> _customerRepo;
        private readonly IGenericRepository<OrderItem> _orderItemRepo;

        public OrderController(IGenericRepository<Order> orderRepo, IGenericRepository<Customer> customerRepo, IGenericRepository<OrderItem> orderItemRepo)
        {
            _orderRepo = orderRepo;
            _customerRepo = customerRepo;
            _orderItemRepo = orderItemRepo;
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
                Customers = _customerRepo.GetAll(),
                AllOrderItems = _orderItemRepo.GetAll().DistinctBy(s => s.Product.Name).ToList(),
                OrderDate = DateTime.Now,
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(OrderViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var Order = new Order()
            {
                CustomerId = vm.CustomerId,
                OrderDate = vm.OrderDate,
                OrderItems = vm.AllOrderItems?.ToList(),
                TotalAmount = vm.AllOrderItems.Where(w => w.Quantity > 0).Sum(s => s.UnitPrice * s.Quantity),
            };

            _orderRepo.Add(Order);
            _orderRepo.Save();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var order = _orderRepo.GetById(id);

            var vm = new OrderViewModel()
            {
                Customers = _customerRepo.GetAll(),
                AllOrderItems = order.OrderItems.ToList(),
                OrderDate = order.OrderDate,
                CustomerId = order.CustomerId,
            };

            return View(vm);
        }

        [HttpPost]

        public IActionResult Edit(int id, OrderViewModel vm)
        {
            var order = _orderRepo.GetById(id);

            order.OrderItems = vm.AllOrderItems.ToList();
            order.CustomerId = vm.CustomerId;
            order.OrderDate = vm.OrderDate;
            order.TotalAmount = vm.AllOrderItems.Where(w => w.Quantity > 0).Sum(s => s.UnitPrice * s.Quantity);

            _orderRepo.Update(order);
            _orderRepo.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var order = _orderRepo.GetById(id);

            return View(order);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = _orderRepo.GetById(id);

            _orderRepo.Delete(order);
            _orderRepo.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var order = _orderRepo.GetById(id);

            return View(order);
        }

    }
}
