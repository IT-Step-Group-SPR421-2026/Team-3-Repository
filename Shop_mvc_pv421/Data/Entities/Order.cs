using Microsoft.AspNetCore.Identity;

namespace Shop_mvc_pv421.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double TotalPrice { get; set; }
        public string UserId { get; set; } = null!;
        public User? User { get; set; }

        public ICollection<OrderDetails>? Items { get; set; }
    }
}
