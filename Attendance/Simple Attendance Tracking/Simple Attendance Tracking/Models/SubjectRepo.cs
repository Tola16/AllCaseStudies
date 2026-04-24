namespace Simple_Attendance_Tracking.Models
{
    public class SubjectRepo : ISubject
    {
        public readonly Context c;
        public SubjectRepo()
        {
            c = new Context();
        }
        public List<Subject> GetAll()
        {
            return c.Subjects.ToList();
        }
        public Subject GetById(int id)
        {
            return c.Subjects.Find(id);
        }
        public void Add(Subject subject)
        {
            c.Subjects.Add(subject);
            c.SaveChanges();
        }
        public void Update(Subject subject)
        {
            c.Subjects.Update(subject);
            c.SaveChanges();
        }
        public void Delete(int id)
        {
            var subject = c.Subjects.Find(id);
            if (subject != null)
            {
                c.Subjects.Remove(subject);
                c.SaveChanges();
            }
        }
    }
}
