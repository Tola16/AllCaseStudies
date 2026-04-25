using CanteenManagementSystem.Data;
using CanteenManagementSystem.Models;
using CanteenManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CanteenManagementSystem.Repositories.Implementaion
{
    public class OrderRepository : IGenericRepository<Order>
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Order entity)
        {
            _context.Orders.Add(entity);
        }

        public void Delete(Order entity)
        {
            _context.Orders.Remove(entity);
        }

        public List<Order> GetAll()
        {
            var Orders = _context.Orders.Include(o => o.User).Include(o => o.FoodItem).Include(o => o.Staff).ToList();

            return Orders;
        }

        public Order GetById(int id)
        {
            var Order = _context.Orders.Include(o => o.User).Include(o => o.FoodItem).Include(o => o.Staff).FirstOrDefault(u => u.OrderId == id);

            return Order;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Order entity)
        {
            _context.Orders.Update(entity);
        }
    }
}
