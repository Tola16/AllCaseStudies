using CanteenManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenManagementSystem.ViewModel
{
    public class CreateStaffViewModel
    {
        public string Name { get; set; }
        public string JonTitle { get; set; }

        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public int CreatedByUserId { get; set; }

        public List<User>? Users { get; set; }
    }
}
