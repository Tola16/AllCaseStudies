using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenManagementSystem.Models
{
    public class FoodItem
    {
        [Key]
        public int FoodItemId { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1, int.MaxValue)]
        public double Price { get; set; }
        [Required]
        public string Category { get; set; }
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }
        public User? User { get; set; }

        public List<Order>? Orders { get; set; }
    }
}
