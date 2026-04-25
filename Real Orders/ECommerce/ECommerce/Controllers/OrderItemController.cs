using ECommerce.Models;
using ECommerce.Repositories.Interfaces;
using ECommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly IGenericRepository<OrderItem> _orderItemRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<Order> _orderRepo;

        public OrderItemController(IGenericRepository<OrderItem> orderItemRepo, IGenericRepository<Product> productRepo, IGenericRepository<Order> orderRepo)
        {
            _orderItemRepo = orderItemRepo;
            _productRepo = productRepo;
            _orderRepo = orderRepo;
        }
        public IActionResult Index()
        {
            var orderItems = _orderItemRepo.GetAll();
            return View(orderItems);
        }
        public IActionResult Create()
        {
            var vm = new OrderItemViewModel()
            {
                Products = _productRepo.GetAll(),
                Orders = _orderRepo.GetAll(),
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(OrderItemViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var orderItem = new OrderItem()
            {
                ProductId = vm.ProductId,
                OrderId = vm.OrderId,
                Quantity = vm.Quantity,
                UnitPrice = _productRepo.GetById(vm.ProductId).Price * vm.Quantity,
            };

            _orderItemRepo.Add(orderItem);
            _orderItemRepo.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var orderItem = _orderItemRepo.GetById(id);

            return View(orderItem);
        }

        public IActionResult Edit(int id)
        {
            var orderItem = _orderItemRepo.GetById(id);

            var vm = new OrderItemViewModel()
            {
                Products = _productRepo.GetAll(),
                Orders = _orderRepo.GetAll(),
                Quantity = orderItem.Quantity,
                ProductId = orderItem.ProductId,
                OrderId = orderItem.OrderId,
            };

            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(int id, OrderItemViewModel vm)
        {
            var orderItem = _orderItemRepo.GetById(id);

            orderItem.OrderId = vm.OrderId;
            orderItem.Quantity = vm.Quantity;
            orderItem.ProductId = vm.ProductId;
            orderItem.UnitPrice = _productRepo.GetById(vm.ProductId).Price * vm.Quantity;

            _orderItemRepo.Update(orderItem);
            _orderItemRepo.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var orderItem = _orderItemRepo.GetById(id);

            return View(orderItem);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var orderItem = _orderItemRepo.GetById(id);
            _orderItemRepo.Delete(orderItem);
            _orderItemRepo.Save();

            return RedirectToAction("Index");
        }

    }
}
