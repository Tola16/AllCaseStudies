namespace Simple_Attendance_Tracking.Models
{
    public class VM
    {
        public int Id { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public int StudentId { get; set; }
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public string Status { get; set; }
        public int SubjectId { get; set; }
        
        public Student Student { get; set; }
            public Subject Subject { get; set; }
    }
}
