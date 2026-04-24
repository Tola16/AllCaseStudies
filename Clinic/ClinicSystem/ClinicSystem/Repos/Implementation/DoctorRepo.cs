using ClinicSystem.Models;
using ClinicSystem.Repos.Interface;
using Microsoft.EntityFrameworkCore;
namespace ClinicSystem.Repos.Implementation
{
    public class DoctorRepo : IGenericRepo<Doctor>
    {
        AppDbContext _db;
        public DoctorRepo(AppDbContext db)
        {
            _db = db;
        }
        public void Add(Doctor entity) => _db.Doctors.Add(entity);

        public void Delete(Doctor entity) => _db.Doctors.Remove(entity);

        public List<Doctor> GetAll() => _db.Doctors.Include(a => a.Appointments).ToList();

        public Doctor GetById(int id) =>
            _db.Doctors.Include(a => a.Appointments)
            .FirstOrDefault(a => a.DoctorID == id);



        public void Save() => _db.SaveChanges();

        public void Update(Doctor entity) => _db.Doctors.Update(entity);
    }
}
