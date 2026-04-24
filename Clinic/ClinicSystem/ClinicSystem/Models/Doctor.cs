using System.ComponentModel.DataAnnotations;

namespace ClinicSystem.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }

        public string ? DoctorName { get; set; }
        public string ? DoctorSpecialty { get; set; }
        public ICollection<Appointment> ? Appointments { get; set; }

    }
}
