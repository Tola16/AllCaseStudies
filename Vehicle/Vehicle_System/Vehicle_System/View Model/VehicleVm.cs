using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Needed for [NotMapped]
using Vehicle_System.Models;

namespace Vehicle_System.View_Model
{
    public class VehicleVm
    {
        [Key]
        public int VehicleId { get; set; }

        public int UserId { get; set; }

        public string? plateNumber { get; set; }

        public string? model { get; set; }

        public int year { get; set; }

        public string Brand { get; set; }

    
        [NotMapped]
        public List<User>? users { get; set; }
    }
}