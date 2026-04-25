using ECommerce.Models;
using ECommerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IGenericRepository<Customer> _customerRepo;

        public CustomerController(IGenericRepository<Customer> cutomerRepo)
        {
            _customerRepo = cutomerRepo;
        }
        public IActionResult Index()
        {
            var customers = _customerRepo.GetAll();
            return View(customers);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer Customer)
        {
            if (!ModelState.IsValid)
                return View(Customer);

            _customerRepo.Add(Customer);
            _customerRepo.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var Customer = _customerRepo.GetById(id);

            if (Customer == null)
                return NotFound();

            return View(Customer);
        }

        public IActionResult Edit(int id)
        {
            var Customer = _customerRepo.GetById(id);

            if (Customer == null)
                return NotFound();

            return View(Customer);
        }
        [HttpPost]
        public IActionResult Edit(Customer Customer)
        {
            if (!ModelState.IsValid)
                return View(Customer);

            _customerRepo.Update(Customer);
            _customerRepo.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var Customer = _customerRepo.GetById(id);

            if (Customer == null)
                return NotFound();

            return View(Customer);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var Customer = _customerRepo.GetById(id);

            _customerRepo.Delete(Customer);
            _customerRepo.Save();

            return RedirectToAction("Index");
        }
    }
}
