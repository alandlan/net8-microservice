using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public class DiscountContext : DbContext
    {
        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {
        }
        public DbSet<Coupon> Coupons { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasKey(x => x.Id);
            modelBuilder.Entity<Coupon>().Property(x => x.ProductName).IsRequired();
            modelBuilder.Entity<Coupon>().Property(x => x.Description).IsRequired();
            modelBuilder.Entity<Coupon>().Property(x => x.Amount).IsRequired();
            modelBuilder.Entity<Coupon>().ToTable("Coupons");

            modelBuilder.Entity<Coupon>().HasData(
                new Coupon
                {
                    Id = 1,
                    ProductName = "IPhone X",
                    Description = "IPhone Discount",
                    Amount = 150
                },
                new Coupon
                {
                    Id = 2,
                    ProductName = "Samsung 10",
                    Description = "Samsung Discount",
                    Amount = 100
                },
                new Coupon
                {
                    Id = 3,
                    ProductName = "Xiaomi Note 10",
                    Description = "Xiaomi Discount",
                    Amount = 50
                }
            );
        }
    }
}
