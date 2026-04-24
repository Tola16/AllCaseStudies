using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClinicSystem.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public string? Notes { get; set; }
        public DateTime Date { get; set; }

        public Doctor ? Doctor { get; set; }
        [ForeignKey("DoctorID")]
        public int DoctorID { get; set; }
        public Patient ? Patient { get; set; }
        [ForeignKey("PatientID")]
        public int PatientID { get; set; }
        
    }

}
