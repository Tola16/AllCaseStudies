using ECommerce.Models;
using ECommerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGenericRepository<Product> _productRepo;

        public ProductController(IGenericRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }
        public IActionResult Index()
        {
            var products = _productRepo.GetAll();
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            _productRepo.Add(product);
            _productRepo.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var product = _productRepo.GetById(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = _productRepo.GetById(id);

            if (product == null)
                return NotFound();

            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            _productRepo.Update(product);
            _productRepo.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = _productRepo.GetById(id);

            if (product == null)
                return NotFound();

            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _productRepo.GetById(id);

            _productRepo.Delete(product);
            _productRepo.Save();

            return RedirectToAction("Index");
        }
    }
}
