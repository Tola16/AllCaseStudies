using System.ComponentModel.DataAnnotations;

namespace CanteenManagementSystem.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 9)]
        public string Password { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public List<Staff>? Staffs { get; set; }

        public List<FoodItem>? FoodItems { get; set; }

        public List<Order>? Orders { get; set; }
    }
}
