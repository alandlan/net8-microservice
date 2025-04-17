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
        }
    }
}
