using System.ComponentModel.DataAnnotations;

namespace Simple_Attendance_Tracking.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}
