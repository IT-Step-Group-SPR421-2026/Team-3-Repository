using Microsoft.EntityFrameworkCore;
using Shop_mvc_pv421.Data;
using Shop_mvc_pv421.Interfaces;
using Shop_mvc_pv421.Services;
using Microsoft.AspNetCore.Identity;
using Shop_mvc_pv421.Data.Entities;
using Shop_mvc_pv421.Extensions;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Runtime.ConstrainedExecution;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

string connStr = builder.Configuration.GetConnectionString("RemoteDb") 
    ?? throw new Exception("No Connection String found.");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

// DI service lifetime
// - transient
// - scoped
// - singleton
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddScoped<IViewRender, ViewRender>();
builder.Services.AddScoped<IFileService, AzureBlobService>();

builder.Services.AddDbContext<ShopDbContext>(options =>
    options.UseSqlServer(connStr));

builder.Services.AddIdentity<User, IdentityRole>(options => 
    options.SignIn.RequireConfirmedAccount = false)
    .AddDefaultUI()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ShopDbContext>();


builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// setup hangfire
builder.Services.AddHangfire(config =>
{
    config.UseSqlServerStorage(connStr);
});

builder.Services.AddHangfireServer();

var app = builder.Build();

// seed initial roles and admin user
using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.SeedRolesAsync().Wait();
    scope.ServiceProvider.SeedAdminAsync().Wait();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.UseHangfireDashboard();

RecurringJob.AddOrUpdate<ProductService>(
                "CleanUp Storage",
                (service) => service.CleanUpProductImages(),
                Cron.Weekly(DayOfWeek.Monday, 3));

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
