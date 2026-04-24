using CinemaSystem.Models;
using Microsoft.EntityFrameworkCore;
using CinemaSystem.Repos.Interfaces;


namespace CinemaSystem.Repos.implement
{
    public class ShowTimeRepo : IGenericRepo<ShowTime>
    {
        public readonly AppDbContext db;
        public ShowTimeRepo(AppDbContext c)
        {
            this.db = c;
        }

        public void Add(ShowTime entity) =>
            db.Add(entity);

        public void Delete(ShowTime Entity) =>
            db.showTimes.Remove(Entity);

        public List<ShowTime> GetAll() =>
        db.showTimes.Include(a=>a.Hall).Include(a=>a.bookings).Include(a=>a.Movie).ToList();


        public ShowTime GetById(int id) =>

        db.showTimes.Include(a => a.Hall).Include(a => a.bookings)
            .Include(a => a.Movie).FirstOrDefault(a => a.Id == id);



        public void save() => db.SaveChanges();

        public void Update(ShowTime entity) => db.Update(entity);

    }
}