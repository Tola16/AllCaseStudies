using CinemaSystem.Models;
using Microsoft.EntityFrameworkCore;
using CinemaSystem.Repos.Interfaces;


namespace CinemaSystem.Repos.implement
{
    public class HallRepo : IGenericRepo<Hall>
    {
        public readonly AppDbContext db;
        public HallRepo(AppDbContext c)
        {
            this.db = c;
        }

        public void Add(Hall entity) =>
            db.Add(entity);

        public void Delete(Hall Entity) =>
            db.halls.Remove(Entity);

        public List<Hall> GetAll() =>
        db.halls.Include(a => a.showTimes).ToList();


        public Hall GetById(int id) =>
          db.halls.Include(a => a.showTimes).FirstOrDefault(u => u.Id == id);


        public void save() => db.SaveChanges();

        public void Update(Hall entity) => db.Update(entity);
    }
}
