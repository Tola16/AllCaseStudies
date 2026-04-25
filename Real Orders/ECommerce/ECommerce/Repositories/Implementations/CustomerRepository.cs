using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Repositories.Interfaces;

namespace ECommerce.Repositories.Implementations
{
    public class CustomerRepository : IGenericRepository<Customer>
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Customer entity)
        {
            _context.Customers.Add(entity);
        }

        public void Delete(Customer entity)
        {
            _context.Customers.Remove(entity);
        }

        public List<Customer> GetAll()
        {
            var Customers = _context.Customers.ToList();

            return Customers;
        }

        public Customer GetById(int id)
        {
            var Customer = _context.Customers.FirstOrDefault(p => p.CustomerId == id);

            return Customer;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Customer entity)
        {
            _context.Customers.Update(entity);
        }
    }
}
