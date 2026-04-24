using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle_System.Models
{
    public class MaintenanceRecord
    {
        [Key]
        public int MaintenanceRecordId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ServiceDate { get; set; }

        [Required]
        public int CurrentKm { get; set; }

        public string ? Notes { get; set; }

        public int VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        public Vehicle ? Vehicle { get; set; }

        public int MaintenanceTypeId { get; set; }
        [ForeignKey("MaintenanceTypeId")]
        public MaintenanceType ? MaintenanceType { get; set; }
    }
}
