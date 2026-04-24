using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Vehicle_System.Interface;
using Vehicle_System.Models;

namespace Vehicle_System.Implementation
{
    public class VehicleRepo : IGenericRepo<Vehicle>
    {
        AppDbContext db;
        public VehicleRepo(AppDbContext db)
        {
            this.db = db;
        }
        public void Add(Vehicle entity)
        {
           db.Vehicles.Add(entity);

        }

        public void Delete(Vehicle Entity)
        {
            db.Vehicles.Remove(Entity);
        }

        public List<Vehicle> GetAll()
        {
            return db.Vehicles.Include(a => a.User).ToList();
        }

        public Vehicle GetById(int id)
        {
            return db.Vehicles.Include(v => v.User).FirstOrDefault(v => v.VehicleId == id);
        }

        public void save()
        {
            db.SaveChanges();
        }

        public void Update(Vehicle entity)
        { 
            db.SaveChanges();
        }
    }
}
