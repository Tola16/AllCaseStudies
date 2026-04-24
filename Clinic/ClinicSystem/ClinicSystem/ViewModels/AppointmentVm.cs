using ClinicSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicSystem.ViewModels
{
    public class AppointmentVm
    {
        [Key]
        public int AppointmentId { get; set; }

        public int DocId { get; set; }
        public int PatId { get; set; }
        
        public string Notes { get; set; }
        public DateTime Date { get; set; }
        [NotMapped]
        public List<Doctor> doctors { get; set; }
        [NotMapped]
        
        public List<Patient> patients { get; set; }

    }
}
