using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using ShefaafSpices.Web.Models;

    namespace ShefaafSpices.Web.Data
    {
        public class AppDbContext : IdentityDbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<Product> Products { get; set; }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Order> Orders { get; set; }
            public DbSet<OrderItem> OrderItems { get; set; }
            public DbSet<NewsletterSubscriber> NewsletterSubscribers { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Product>()
                    .Property(p => p.Price)
                    .HasPrecision(18, 4);

                modelBuilder.Entity<Order>()
                    .Property(o => o.TotalAmount)
                    .HasPrecision(18, 4);

                modelBuilder.Entity<OrderItem>()
                    .Property(oi => oi.UnitPrice)
                    .HasPrecision(18, 4);
            }
        }
    }