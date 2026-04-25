using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;
using SchoolSystem.Repos.Interface;

namespace SchoolSystem.Repos.Implementations
{
    public class StudentRepo : IGenericRepo<Student>
    {
        AppDbContext db;
        public StudentRepo(AppDbContext Db) => db = Db;

        public void Add(Student entity) => db.Students.Add(entity);


        public void Delete(Student entity) => db.Students.Remove(entity);

        public List<Student> GetAll() => db.Students.Include(a => a.Enrollments).ToList();

        public Student GetById(int id) => db.Students.Include(a => a.Enrollments).
            FirstOrDefault(a => a.Id == id);


        public void Save() => db.SaveChanges();

        public void Update(Student entity) => db.Students.Update(entity);
    }
}
