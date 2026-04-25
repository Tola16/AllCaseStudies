using ECommerce.Models;

namespace ECommerce.ViewModels
{
    public class OrderItemViewModel
    {
        public int OrderId { get; set; }
        public List<Order>? Orders { get; set; }
        public List<Product>? Products { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Product? Product { get; set; }
        //public int UnitPrice { get; set; }


    }
}
