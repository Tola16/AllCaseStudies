using CanteenManagementSystem.Data;
using CanteenManagementSystem.Models;
using CanteenManagementSystem.Repositories.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace CanteenManagementSystem.Repositories.Implementaion
{
    public class StaffRepository : IGenericRepository<Staff>
    {
        private readonly AppDbContext _context;

        public StaffRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Staff entity)
        {
            _context.Staffs.Add(entity);
        }

        public void Delete(Staff entity)
        {
            var orders = _context.Orders.Where(o => o.StaffId == entity.StaffId);
            _context.Orders.RemoveRange(orders);
            _context.Staffs.Remove(entity);
        }

        public List<Staff> GetAll()
        {
            var Staffs = _context.Staffs.Include(s => s.Orders).Include(s => s.User).ToList();

            return Staffs;
        }

        public Staff GetById(int id)
        {
            var Staff = _context.Staffs.Include(s => s.Orders).Include(s => s.User).FirstOrDefault(u => u.StaffId == id);

            return Staff;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Staff entity)
        {
            _context.Staffs.Update(entity);
        }
    }
}
