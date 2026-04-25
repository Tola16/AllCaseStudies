using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email {  get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
