using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Models
{

    public class Enrollment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        [Required]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        public DateOnly RegisterDate { get; set; }
    }
}