using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace CanteenManagementSystem.Models
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string JonTitle { get; set; }
        [StringLength(11, MinimumLength = 11)]
        [Required]
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }
        public User? User { get; set; }

        public List<Order>? Orders { get; set; }
    }

}
