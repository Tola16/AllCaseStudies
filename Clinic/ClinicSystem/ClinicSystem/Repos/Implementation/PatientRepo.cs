using ClinicSystem.Models;
using ClinicSystem.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace ClinicSystem.Repos.Implementation
{
    public class PatientRepo : IGenericRepo<Patient>
    {
        AppDbContext _db;
        public PatientRepo(AppDbContext db)
        {
            _db = db;
        }
        public void Add(Patient entity) => _db.Patients.Add(entity);

        public void Delete(Patient entity) => _db.Patients.Remove(entity);

        public List<Patient> GetAll() => _db.Patients.Include(a => a.Appointments).ToList();

        public Patient GetById(int id) =>
            _db.Patients.Include(a => a.Appointments)
            .FirstOrDefault(a => a.PatientID == id);



        public void Save() => _db.SaveChanges();

        public void Update(Patient entity) => _db.Patients.Update(entity);
    }
}
