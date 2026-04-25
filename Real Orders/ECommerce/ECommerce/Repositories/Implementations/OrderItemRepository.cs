using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repositories.Implementations
{
    public class OrderItemRepository : IGenericRepository<OrderItem>
    {
        private readonly AppDbContext _context;

        public OrderItemRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(OrderItem entity)
        {
            _context.OrderItems.Add(entity);
        }

        public void Delete(OrderItem entity)
        {
            _context.OrderItems.Remove(entity);
        }

        public List<OrderItem> GetAll()
        {
            var OrderItems = _context.OrderItems.Include(OrderItem => OrderItem.Order).Include(oi => oi.Product).ToList();

            return OrderItems;
        }

        public OrderItem GetById(int id)
        {
            var OrderItem = _context.OrderItems.Include(OrderItem => OrderItem.Order).Include(oi => oi.Product).FirstOrDefault(p => p.OrderItemId == id);

            return OrderItem;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(OrderItem entity)
        {
            _context.OrderItems.Update(entity);
        }
    }
}
