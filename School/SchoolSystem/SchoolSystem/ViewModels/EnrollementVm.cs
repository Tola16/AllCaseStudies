using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.ViewModels
{
    public class EnrollementVm
    {

        [Key]
        public int id { get; set; }
        [NotMapped]
        public List<Student> Students { get; set; } = new List<Student>();
        [NotMapped]
        public List<Course> Courses { get; set; } = new List<Course>();
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public DateOnly DateTime { get; set; }

    }
}
