using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;
using SchoolSystem.Repos.Interface;

namespace SchoolSystem.Repos.Implementations
{
    public class CourseRepo : IGenericRepo<Course>
    {
        AppDbContext db;
        public CourseRepo(AppDbContext Db)=>db = Db;

        public void Add(Course entity)=>db.Courses.Add(entity);


        public void Delete(Course entity)=> db.Courses.Remove(entity);

        public List<Course> GetAll() => db.Courses.Include(a => a.Enrollments).ToList();

        public Course GetById(int id) => db.Courses.Include(a => a.Enrollments).
            FirstOrDefault(a => a.Id == id);


        public void Save() => db.SaveChanges();

        public void Update(Course entity)=>db.Courses.Update(entity);
    }
}
