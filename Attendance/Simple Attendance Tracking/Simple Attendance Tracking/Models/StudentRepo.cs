using Microsoft.EntityFrameworkCore;

namespace Simple_Attendance_Tracking.Models
{
    public class StudentRepo : IStudent
    {
        public readonly Context c;
        public StudentRepo()
        {
            c = new Context();
        }
        public List<Student> GetAll()
        {
            return c.Students.ToList();
        }

        public Student GetById(int id)//5
        {
            return c.Students.Find(id);//5
        }

        public void Add(Student student)
        {
            c.Students.Add(student);
            c.SaveChanges();
        }

        public void Update(Student student)
        {
            c.Students.Update(student);
            c.SaveChanges();
        }

        public void Delete(int id)//5
        {
            var student = c.Students.Find(id);//5
            if (student != null)
            {
                c.Students.Remove(student);
                c.SaveChanges();
            }
        }
    }
}
