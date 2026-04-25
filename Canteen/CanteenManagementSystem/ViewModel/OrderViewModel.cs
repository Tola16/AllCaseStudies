using CanteenManagementSystem.Models;

namespace CanteenManagementSystem.ViewModel
{
    public class OrderViewModel
    {
        public DateTime OrderDateTime { get; set; }

        public string Status { get; set; }

        public int StaffId { get; set; }

        public List<Staff>? Staff { get; set; }
        public int FoodItemId { get; set; }

        public List<FoodItem>? FoodItems { get; set; }

        public int CustomerId { get; set; }
        public List<User>? Customers {  get; set; }

        public double TotalPrice { get; set; }

    }
}
