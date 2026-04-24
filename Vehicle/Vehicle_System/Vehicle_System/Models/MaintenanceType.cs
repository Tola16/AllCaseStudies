using System.ComponentModel.DataAnnotations;

namespace Vehicle_System.Models
{
    public class MaintenanceType
    {
        [Key]
        public int MaintenanceTypeId { get; set; }

        [Required]
        public string ? Name { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int RecommendedKm { get; set; }

        public ICollection<MaintenanceRecord>  ? MaintenanceRecords { get; set; }
    }
}
