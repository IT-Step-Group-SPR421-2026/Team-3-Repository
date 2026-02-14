using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_mvc_pv421.Data;
using Shop_mvc_pv421.Extensions;
using Shop_mvc_pv421.Interfaces;

namespace Shop_mvc_pv421.Controllers
{
    public class CartController : Controller
    {
        private readonly ShopDbContext ctx;
        private readonly ICartService cartService;

        public CartController(ShopDbContext ctx, ICartService cartService)
        {
            this.ctx = ctx;
            this.cartService = cartService;
        }
        // GET: Cart
        public ActionResult Index()
        {
            var items = cartService.GetProducts();

            return View(items);
        }
        
        public ActionResult Add(int id) // 3, 5
        {
            cartService.Add(id);
            
            return RedirectToAction("Index", "Home");
        }

        // TODO: implement remove

        public ActionResult Clear()
        {
            cartService.Clear();

            return RedirectToAction("Index");
        }
    }
}
