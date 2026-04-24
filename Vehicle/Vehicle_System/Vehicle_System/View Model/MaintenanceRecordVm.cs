using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vehicle_System.Models;
using static Azure.Core.HttpHeader;
namespace Vehicle_System.View_Model
{
    public class MaintenanceRecordVm
    {
        [Key]
        public int MaintenanceRecordId { get; set; }
        public int VehicleId { get; set; }
        public DateTime ServiceDate { get; set; }
        [Range(0, int.MaxValue)]
        public int CurrentKm { get; set; } 
        public string ? Notes { get; set; }
        public int MaintenanceTypeId { get; set; }
        [NotMapped]

        public List<Vehicle> Vehicles { get; set; }
        [NotMapped]

        public List<MaintenanceType> MaintenanceTypes { get; set; }
    }
}
//Service Date(Cannot be in the future)
//Vehicle(Drop - down list)
//Maintenance Type(Drop-down list)
//Current Km(Must be greater than 0)
//Notes