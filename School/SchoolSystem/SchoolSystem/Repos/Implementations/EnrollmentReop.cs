using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;
using SchoolSystem.Repos.Interface;

namespace SchoolSystem.Repos.Implementations
{
    public class EnrollmentReop : IGenericRepo<Enrollment>
    {
        AppDbContext db;
        public EnrollmentReop(AppDbContext Db) => db = Db;

        public void Add(Enrollment entity) => db.Enrollments.Add(entity);


        public void Delete(Enrollment entity) => db.Enrollments.Remove(entity);

        public List<Enrollment> GetAll() => db.Enrollments.Include(a => a.Student).Include(a=>a.Course).ToList();

        public Enrollment GetById(int id) => db.Enrollments.Include(a => a.Student).Include(a => a.Course).
            FirstOrDefault(a => a.Id == id);


        public void Save() => db.SaveChanges();

        public void Update(Enrollment entity) => db.Enrollments.Update(entity);
    }
}
