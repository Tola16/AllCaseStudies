using CanteenManagementSystem.Models;
using CanteenManagementSystem.Repositories.Interfaces;
using CanteenManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CanteenManagementSystem.Controllers
{
    public class FoodItemController : Controller
    {
        private readonly IGenericRepository<FoodItem> _foodItemRepo;
        private readonly IGenericRepository<User> _userRepo;

        public FoodItemController(IGenericRepository<FoodItem> foodItemRepo, IGenericRepository<User> userRepo)
        {
            _foodItemRepo = foodItemRepo;
            _userRepo = userRepo;
        }
        public IActionResult Index()
        {
            var foodItems = _foodItemRepo.GetAll();
            return View(foodItems);
        }

        public IActionResult Create()
        {
            var vm = new FoodItemViewModel()
            {
                Users = _userRepo.GetAll()
            };

            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(FoodItemViewModel vm)
        {
            if(!ModelState.IsValid)
                return View(vm);

            var foodItem = new FoodItem()
            {
                Name = vm.Name,
                Category = vm.Category,
                Price = vm.Price,
                UserId = vm.UserId,
            };
            _foodItemRepo.Add(foodItem);
            _foodItemRepo.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var foodItem = _foodItemRepo.GetById(id);

            if (foodItem == null)
                return NotFound();

            return View(foodItem);
        }

        public IActionResult Edit(int id)
        {
            var foodItem = _foodItemRepo.GetById(id);
            if (foodItem == null)
                return NotFound();

            var vm = new FoodItemViewModel()
            {
                Name = foodItem.Name,
                Price = foodItem.Price,
                Category = foodItem.Category,
                Users = _userRepo.GetAll(),
                UserId = foodItem.UserId,
            };

            return View(vm);

        }
        [HttpPost]
        public IActionResult Edit(int id, FoodItemViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Users = _userRepo.GetAll();
                return View(vm);
            }

            var foodItem = _foodItemRepo.GetById(id);
            if (foodItem == null)
                return NotFound();

            foodItem.Name = vm.Name;
            foodItem.Price = vm.Price;
            foodItem.Category = vm.Category;
            foodItem.UserId = vm.UserId;
            _foodItemRepo.Update(foodItem);
            _foodItemRepo.Save();

            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            var foodItem = _foodItemRepo.GetById(id);

            if (foodItem == null)
                return NotFound();

            return View(foodItem);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var foodItem = _foodItemRepo.GetById(id);
            if (foodItem == null)
                return NotFound();

            _foodItemRepo.Delete(foodItem);
            _foodItemRepo.Save();

            return RedirectToAction("Index");
        }
    }
}
