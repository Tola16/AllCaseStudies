namespace Simple_Attendance_Tracking.Models
{
    public interface IAttendance
    {
        Attendance GetById(int id);
        void Add(VM attendance);
        void Update(VM attendance);
        void Delete(int id);
        List<Attendance> GetAll(int? studentId, int? subjectId);
    }
}
