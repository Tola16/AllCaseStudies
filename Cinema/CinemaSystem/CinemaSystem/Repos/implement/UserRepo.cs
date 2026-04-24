using CinemaSystem.Models;
using Microsoft.EntityFrameworkCore;
using CinemaSystem.Repos.Interfaces;


namespace CinemaSystem.Repos.implement
{
    public class UserRepo : IGenericRepo<User>
    {
        public readonly AppDbContext db;
        public UserRepo(AppDbContext c)
        {
            this.db = c;
        }

        public void Add(User entity) =>
            db.Add(entity);

        public void Delete(User Entity) =>
            db.Users.Remove(Entity);

        public List<User> GetAll() =>
        db.Users.Include(a => a.Bookings).ToList();


        public User GetById(int id) => db.Users.Include(a => a.Bookings).FirstOrDefault(u => u.Id == id);


        public void save() => db.SaveChanges();

        public void Update(User entity) => db.Update(entity);
    }
}
