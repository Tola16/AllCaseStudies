using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
using Vehicle_System.Interface;
using Vehicle_System.Models;

namespace Vehicle_System.Implementation
{
    public class UserRepo : IGenericRepo<User>
    {
        AppDbContext db;
        public UserRepo(AppDbContext db)
        {
            this.db = db;
        }
        public void Add(User entity)
        {
          db.Add(entity);
        }

        public void Delete(User Entity)
        {
            db.Users.Remove(Entity);
        }

        public List<User> GetAll()
        {
            return db.Users.Include(u => u.Vehicles).ToList();
        }

        public User GetById(int id)
        {
            return db.Users.Include(u => u.Vehicles).FirstOrDefault(u => u.UserId == id);
        }

        public void save()
        {
            db.SaveChanges();
        }

        public void Update(User entity)
        {
            db.Users.Update(entity);
        }
        }
    }

