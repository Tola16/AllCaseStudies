using CanteenManagementSystem.Data;
using CanteenManagementSystem.Models;
using CanteenManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CanteenManagementSystem.Repositories.Implementaion
{
    public class FoodItemRepository : IGenericRepository<FoodItem>
    {
        private readonly AppDbContext _context;

        public FoodItemRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(FoodItem entity)
        {
            _context.FoodItems.Add(entity);
        }

        public void Delete(FoodItem entity)
        {
            _context.FoodItems.Remove(entity);
        }

        public List<FoodItem> GetAll()
        {
            var FoodItems = _context.FoodItems.Include(fi => fi.Orders).Include(fi => fi.User).ToList();

            return FoodItems;
        }

        public FoodItem GetById(int id)
        {
            var FoodItem = _context.FoodItems.Include(fi => fi.Orders).Include(fi => fi.User).FirstOrDefault(u => u.FoodItemId == id);

            return FoodItem;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(FoodItem entity)
        {
            _context.FoodItems.Update(entity);
        }
    }
}
