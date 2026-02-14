using Shop_mvc_pv421.Data.Entities;

namespace Shop_mvc_pv421.Models
{
    public class OrderSummaryModel
    {
        public string UserName { get; set; }
        public int OrderNumber { get; set; }
        public double TotalPrice { get; set; }
        public int ItemsCount { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
