using CinemaSystem.Models;
using Microsoft.EntityFrameworkCore;
using CinemaSystem.Repos.Interfaces;

namespace CinemaSystem.Repos.implement
{
    public class BookingRepo : IGenericRepo<Booking>
    {
        AppDbContext db;
        public BookingRepo(AppDbContext db)
        {
            this.db = db;
        }
        public void Add(Booking entity)=>
            db.Add(entity);

        public void Delete(Booking Entity)=>
            db.bookings.Remove(Entity);

        public List<Booking> GetAll() =>
        db.bookings.Include(u => u.User)
                .Include(a => a.ShowTime).ToList();


        public Booking GetById(int id) =>

             db.bookings.Include(u => u.User)
                .Include(a => a.ShowTime).FirstOrDefault(u => u.Id == id);


        public void save() => db.SaveChanges();

        public void Update(Booking entity)=>db.Update(entity);
    }
}