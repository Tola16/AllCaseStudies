using Microsoft.EntityFrameworkCore;
using Vehicle_System.Interface;
using Vehicle_System.Models;

namespace Vehicle_System.Implementation
{
    public class MaintenanceRecordRepo : IGenericRepo<MaintenanceRecord>
    {
        AppDbContext db;
        public MaintenanceRecordRepo(AppDbContext db)
        {
            this.db = db;
        }
        public void Add(MaintenanceRecord entity)
        {
            db.MaintenanceRecords.Add(entity);
        }

        public void Delete(MaintenanceRecord Entity)
        {
            db.MaintenanceRecords.Remove(Entity);
        }

        public List<MaintenanceRecord> GetAll()
        {
            return db.MaintenanceRecords.Include(u => u.Vehicle).Include(a=>a.MaintenanceType).ToList();
        }

        public MaintenanceRecord GetById(int id)
        {
            return db.MaintenanceRecords.Include(u => u.Vehicle).Include(a => a.MaintenanceType).FirstOrDefault(u => u.MaintenanceRecordId == id);
        }

        public void save()
        {
            db.SaveChanges();
        }

        public void Update(MaintenanceRecord entity)
        {
            db.MaintenanceRecords.Update(entity);
        }

    }
}
