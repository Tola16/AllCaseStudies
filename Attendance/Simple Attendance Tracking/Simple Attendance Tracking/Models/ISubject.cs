namespace Simple_Attendance_Tracking.Models
{
    public interface ISubject
    {
        List<Subject> GetAll();
        Subject GetById(int id);
        void Add(Subject subject);
        void Update(Subject subject);
        void Delete(int id);

    }
}
