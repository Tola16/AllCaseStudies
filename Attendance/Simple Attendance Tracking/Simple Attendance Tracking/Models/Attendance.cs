using System.ComponentModel.DataAnnotations;

namespace Simple_Attendance_Tracking.Models
{
    public class Attendance
    {
        [Key]   
            public int Id { get; set; }
        public DateOnly Date { get; set; }

        public string Status{ get; set; }
public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }

    }
}
