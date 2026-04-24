using ClinicSystem.Repos.Interface;
using ClinicSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicSystem.Repos.Implementation
{
    public class AppointmentRepo : IGenericRepo<Appointment>
    {
        AppDbContext _db;
        public AppointmentRepo(AppDbContext db)
        {
            _db = db;
        }
        public void Add(Appointment entity) => _db.Appointments.Add(entity);

        public void Delete(Appointment entity) => _db.Appointments.Remove(entity);

        public List<Appointment> GetAll() => _db.Appointments.Include(a => a.Doctor).Include(a => a.Patient).ToList();

        public Appointment GetById(int id) =>
            _db.Appointments.Include(a => a.Doctor)
            .Include(a => a.Patient)
            .FirstOrDefault(a => a.AppointmentId == id);



        public void Save() => _db.SaveChanges();

        public void Update(Appointment entity) => _db.Appointments.Update(entity);
    }
}
