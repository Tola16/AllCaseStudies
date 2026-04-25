using Microsoft.EntityFrameworkCore;
namespace Simple_Attendance_Tracking.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Student)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.StudentId);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Subject)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.SubjectId);
        }
    }
}
