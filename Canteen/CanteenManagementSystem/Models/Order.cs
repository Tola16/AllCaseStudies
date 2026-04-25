using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenManagementSystem.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime OrderDateTime { get; set; }
        public string Status { get; set; }
        [ForeignKey(nameof(StaffId))]
        public int StaffId { get; set; }
        public Staff? Staff { get; set; }
        [ForeignKey(nameof(FoodItemId))]

        public int FoodItemId { get; set; }
        public FoodItem? FoodItem { get; set; }
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }
        public User? User { get; set; }

        public double TotalPrice { get; set; }

    }
}
