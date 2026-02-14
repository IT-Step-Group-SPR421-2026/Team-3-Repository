using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_mvc_pv421.Data;
using Shop_mvc_pv421.Data.Entities;
using Shop_mvc_pv421.Interfaces;
using Shop_mvc_pv421.Models;
using System.Security.Claims;

namespace Shop_mvc_pv421.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly ShopDbContext ctx;
        private readonly ICartService cartService;
        private readonly IEmailSender emailSender;
        private readonly IViewRender viewRender;

        private string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        private string CurrentUserEmail => User.FindFirstValue(ClaimTypes.Email)!;

        public OrdersController(
            ShopDbContext ctx, 
            ICartService cartService, 
            IEmailSender emailSender,
            IViewRender viewRender)
        {
            this.ctx = ctx;
            this.cartService = cartService;
            this.emailSender = emailSender;
            this.viewRender = viewRender;
        }
        public IActionResult Index()
        {
            var orders = ctx.Orders
                .Include(x => x.Items)
                .Include(x => x.User)
                .Where(x => x.UserId == CurrentUserId) // лише замовлення поточного користувача
                .ToList();

            return View(orders);
        }

        public IActionResult Add()
        {
            var products = cartService.GetProducts();

            var order = new Order()
            {
                Date = DateTime.UtcNow,
                UserId = CurrentUserId,
                TotalPrice = (double)products.Sum(x => x.Price), 
            };
            ctx.Orders.Add(order);
            ctx.SaveChanges();

            var details = new List<OrderDetails>();
            foreach (var product in products)
            {
                details.Add(new OrderDetails()
                {
                    Quantity = 1,
                    ProductId = product.Id,
                    OrderId = order.Id
                });
            }

            ctx.OrderDetails.AddRange(details);            
            ctx.SaveChanges();

            cartService.Clear();

            // send email to client with order details
            var html = viewRender.Render("MailTemplates/OrderSummary", new OrderSummaryModel
            {
                OrderNumber = order.Id,
                UserName = CurrentUserEmail,
                Products = products,
                TotalPrice = order.TotalPrice,
                ItemsCount = products.Count
            });

            emailSender.SendEmailAsync(CurrentUserEmail, $"New Order #{order.Id}", html);

            return RedirectToAction("Index");
        }
    }
}
