using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)] 
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
