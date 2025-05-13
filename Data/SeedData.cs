using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShefaafSpices.Web.Models;
namespace ShefaafSpices.Web.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Create Admin Role
            string roleName = "Admin";
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            // Create Admin User
            string adminEmail = "admin@shefaaf.com";
            string adminPassword = "Admin@123";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail };
                await userManager.CreateAsync(adminUser, adminPassword);
            }

            // Assign Admin Role to User
            if (!await userManager.IsInRoleAsync(adminUser, roleName))
            {
                await userManager.AddToRoleAsync(adminUser, roleName);
            }

            // Seed Categories and Products
            if (!await context.Categories.AnyAsync())
            {
                context.Categories.AddRange(
                    new Category { Name = "Spices" },
                    new Category { Name = "Herbs" }
                );
                await context.SaveChangesAsync();
            }

            if (!await context.Products.AnyAsync())
            {
                var category = await context.Categories.FirstOrDefaultAsync(c => c.Name == "Spices");
                if (category != null)
                {
                    context.Products.AddRange(
                        new Product
                        {
                            Name = "Turmeric Powder",
                            Description = "Pure turmeric powder for cooking.",
                            Price = 5.99m,
                            StockQuantity = 100,
                            ImageUrl = "/img/turmeric.jpg",
                            CategoryId = category.Id
                        }
                    );
                }
                await context.SaveChangesAsync();
            }
        }
    }
}