using Microsoft.AspNetCore.Identity;
using Shop_mvc_pv421.Data.Entities;
using System.Reflection;
using System;

namespace Shop_mvc_pv421.Extensions
{
    public static class Roles
    {
        public const string ADMIN = "admin";
        public const string USER = "user";
    }

    public static class IdentityInitializerExtensions
{
        public static async Task SeedRolesAsync(this IServiceProvider app)
        {
            var roleManager = app.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(Roles.ADMIN))
                await roleManager.CreateAsync(new(Roles.ADMIN));

            if (!await roleManager.RoleExistsAsync(Roles.USER))
                await roleManager.CreateAsync(new(Roles.USER));
        }

        public static async Task SeedAdminAsync(this IServiceProvider app)
        {
            var userManager = app.GetRequiredService<UserManager<User>>();
            var configuration = app.GetRequiredService<IConfiguration>();

            const string USERNAME = "admin@ukr.net";
            // Read from environment variable or configuration, with a secure default for development
            var password = Environment.GetEnvironmentVariable("AdminPassword")
                         ?? configuration["AdminPassword"]
                         ?? "ChangeThisPassword123!";

            var existingUser = await userManager.FindByNameAsync(USERNAME);

            if (existingUser == null)
            {
                var user = new User
                {
                    UserName = USERNAME,
                    Email = USERNAME,
                };

                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                    await userManager.AddToRoleAsync(user, Roles.ADMIN);
            }
        }
    }
}
