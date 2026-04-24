using Microsoft.EntityFrameworkCore;

namespace Simple_Attendance_Tracking.Models
{
    public class AttendanceRepo : IAttendance
    {
        public readonly Context c;
        public AttendanceRepo()
        {
            c = new Context();
        }
        public List<Attendance> GetAll()
        {
            return c.Attendances.Include(a => a.Student).Include(Student => Student.Subject).ToList();
        }
        public Attendance GetById(int id)
        {
            return c.Attendances
                    .Include(a => a.Student)
                    .Include(a => a.Subject)
                    .FirstOrDefault(a => a.Id == id);
        }
        public void Add(VM attendance)
        {
            var newAttendance = new Attendance
            {
                StudentId = attendance.StudentId,
                SubjectId = attendance.SubjectId,
                Date = DateOnly.FromDateTime(DateTime.Now),
                Status = attendance.Status
            };
            c.Attendances.Add(newAttendance);
            c.SaveChanges();
        }
        public void Update(VM attendance)
        {
            var existingAttendance = c.Attendances.Find(attendance.Id);
            if (existingAttendance != null)
            {
                existingAttendance.Status = attendance.Status;
                c.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var attendance = c.Attendances.Find(id);
            if (attendance != null)
            {
                c.Attendances.Remove(attendance);
                c.SaveChanges();
            }
        }

  

    
    }
}
