using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Models
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }
             [Required] 
     
    [DataType(DataType.Date)]
        public int StudentId { get; set; }
        [ForeignKey("Student")]
        public int CourseId { get; set; }
        [ForeignKey("Course")]

        [DataType(DataType.Date)]

        public DateOnly RegisterDate { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
