using ECommerce.Models;

namespace ECommerce.ViewModels
{
    public class OrderViewModel
    {
        public int CustomerId { get; set; }
        public List<Customer>? Customers { get; set; }

        public List<OrderItem>? AllOrderItems { get; set; }

        public DateTime OrderDate {  get; set; }

    }
}
