using CanteenManagementSystem.Data;
using CanteenManagementSystem.Models;
using CanteenManagementSystem.Repositories.Interfaces;
using CanteenManagementSystem.ViewModel;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace CanteenManagementSystem.Repositories.Implementaion
{
    public class UserRepository : IGenericRepository<User>
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(User entity)
        {
            _context.Users.Add(entity);
        }

        public void Delete(User entity)
        {
            _context.Users.Remove(entity);
        }

        public List<User> GetAll()
        {
            var users = _context.Users.ToList();

            return users;
        }

        public User GetById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);

            return user;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
        }

        public bool GetUser(LoginViewModel vm)
        {
            return _context.Users.FirstOrDefault(u => u.Email == vm.Email && u.Password == vm.Password) != null;
        }
    }
}
