using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace ClinicSystem.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }
        public string ? PatientName { get; set; }
        public int Age { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }

    }
}
