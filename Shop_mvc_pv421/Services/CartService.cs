using Microsoft.EntityFrameworkCore;
using Shop_mvc_pv421.Data;
using Shop_mvc_pv421.Data.Entities;
using Shop_mvc_pv421.Extensions;
using Shop_mvc_pv421.Interfaces;

namespace Shop_mvc_pv421.Services
{
    public class CartService : ICartService
    {
        private readonly HttpContext httpContext;
        private readonly ShopDbContext ctx;

        public CartService(ShopDbContext ctx, IHttpContextAccessor contextAccessor)
        {
            this.httpContext = contextAccessor.HttpContext ?? throw new Exception("HttpContext is null.");
            this.ctx = ctx;
        }

        public void Add(int id)
        {
            var existingIds = httpContext.Session.Get<List<int>>("CartItems");
            List<int> ids = existingIds ?? new();

            ids.Add(id);

            httpContext.Session.Set("CartItems", ids);
        }

        public void Clear()
        {
            httpContext.Session.Remove("CartItems");
        }

        public int GetCartSize()
        {
            var ids = httpContext.Session.Get<List<int>>("CartItems");
            return ids?.Count ?? 0;
        }

        public List<int> GetItemIds()
        {
            return httpContext.Session.Get<List<int>>("CartItems") ?? new List<int>();
        }

        public List<Product> GetProducts()
        {
            var existingIds = GetItemIds();

            return ctx.Products
                .Include(x => x.Category)
                .Where(x => existingIds.Contains(x.Id))
                .ToList();
        }
    }
}
