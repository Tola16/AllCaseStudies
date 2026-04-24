namespace Simple_Attendance_Tracking.Models
{
    public interface IStudent
    {
         List<Student> GetAll();
        Student GetById(int id);
        void Add(Student student);
        void Update(Student student);
        void Delete(int id);

    }
}
