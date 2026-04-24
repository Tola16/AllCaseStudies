using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace ClinicSystem.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }
        
        public string ? PatientName { get; set; }
        [MinLength(1)]
        [MaxLength(7)]
        public string Age { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }

    }
}
