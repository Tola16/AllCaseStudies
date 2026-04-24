using Microsoft.EntityFrameworkCore;
using ClinicSystem.ViewModels;

namespace ClinicSystem.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ClinicSystem.ViewModels.AppointmentVm> AppointmentVm { get; set; } = default!;


    }
}
