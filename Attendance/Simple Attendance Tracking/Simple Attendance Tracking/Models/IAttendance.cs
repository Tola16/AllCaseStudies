namespace Simple_Attendance_Tracking.Models
{
    public interface IAttendance
    {
        List<Attendance> GetAll();
        Attendance GetById(int id);
        void Add(VM attendance);
        void Update(VM attendance);
        void Delete(int id);
    }
}
