using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Range(1, 6)]
        public int Credits { get; set; }


        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>(); 
    }
}
