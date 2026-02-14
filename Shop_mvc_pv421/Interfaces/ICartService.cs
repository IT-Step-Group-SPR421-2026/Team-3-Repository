using Shop_mvc_pv421.Data.Entities;

namespace Shop_mvc_pv421.Interfaces
{
    public interface ICartService
    {
        List<int> GetItemIds();
        List<Product> GetProducts();

        void Add(int id);
        void Clear();
        int GetCartSize();
    }
}
