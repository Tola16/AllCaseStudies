using Microsoft.Build.ObjectModelRemoting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle_System.Models
{
    public class Vehicle 
    {
        [Key]
        public int VehicleId { get; set; }

        [Required]
        public string ? PlateNumber { get; set; }

        public string ? Brand { get; set; }

        public string ? Model { get; set; }

        [Required]
        [Range(1990, 2026)]
        public int Year { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User ? User { get; set; }
       
        public ICollection<MaintenanceRecord> ? MaintenanceRecords { get; set; }
    }
}
