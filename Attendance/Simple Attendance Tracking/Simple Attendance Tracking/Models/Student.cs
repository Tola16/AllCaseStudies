using System.ComponentModel.DataAnnotations;

namespace Simple_Attendance_Tracking.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Attendance> Attendances { get; set; }   = new List<Attendance>();
    }
}
