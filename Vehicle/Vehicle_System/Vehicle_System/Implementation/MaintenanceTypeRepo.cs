using Microsoft.EntityFrameworkCore;
using Vehicle_System.Interface;
using Vehicle_System.Models;

namespace Vehicle_System.Implementation
{
    public class MaintenanceTypeRepo : IGenericRepo<MaintenanceType>
    {
        AppDbContext db;
        public MaintenanceTypeRepo(AppDbContext db)
        {
            this.db = db;
        }
        public void Add(MaintenanceType entity)
        {
            db.Add(entity);
        }

        public void Delete(MaintenanceType entity)
        {
            db.MaintenanceTypes.Remove(entity);
        }

        public List<MaintenanceType> GetAll()
        {
            return db.MaintenanceTypes.Include(a=>a.MaintenanceRecords).ToList();
        }

        public MaintenanceType GetById(int id)
        {
            return db.MaintenanceTypes.Include(a => a.MaintenanceRecords).FirstOrDefault(a => a.MaintenanceTypeId == id);
        }

        public void save()
        {
            db.SaveChanges();
        }

        public void Update(MaintenanceType entity)
        {
            db.MaintenanceTypes.Update(entity);
        }
    }
}
