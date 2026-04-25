using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repositories.Implementations
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
            var Orders = _context.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Product).Include(o => o.Customer).ToList();

            return Orders;
        }

        public Order GetById(int id)
        {
            var Order = _context.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Product).Include(o => o.Customer).FirstOrDefault(p => p.OrderId == id);

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
