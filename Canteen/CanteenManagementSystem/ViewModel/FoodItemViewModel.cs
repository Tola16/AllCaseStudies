using CanteenManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenManagementSystem.ViewModel
{
    public class FoodItemViewModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public int UserId { get; set; }

        public List<User>? Users { get; set; }
    }
}
