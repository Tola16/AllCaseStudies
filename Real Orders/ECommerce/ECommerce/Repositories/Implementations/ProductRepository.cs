using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ECommerce.Repositories.Implementations
{
    public class ProductRepository : IGenericRepository<Product>
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Product entity)
        {
            _context.Products.Add(entity);
        }

        public void Delete(Product entity)
        {
            _context.Products.Remove(entity);
        }

        public List<Product> GetAll()
        {
            var products = _context.Products.ToList();

            return products;
        }

        public Product GetById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);

            return product;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Product entity)
        {
            _context.Products.Update(entity);
        }
    }
}
