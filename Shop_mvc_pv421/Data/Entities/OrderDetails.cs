namespace Shop_mvc_pv421.Data.Entities
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
