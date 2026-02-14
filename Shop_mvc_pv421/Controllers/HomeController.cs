using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_mvc_pv421.Data;
using Shop_mvc_pv421.Models;
using System.Diagnostics;

namespace Shop_mvc_pv421.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopDbContext ctx;

        public HomeController(ShopDbContext ctx)
        {
            this.ctx = ctx;
        }

        public IActionResult Index()
        {
            var products = ctx.Products.Include(x => x.Category).ToList();
            return View(products);
        }

        public IActionResult About()
        {
            // do logic here if needed
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
