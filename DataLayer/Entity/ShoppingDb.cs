using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("BuildEF")]
[assembly: InternalsVisibleTo("Service")]
namespace DataLayer.Entity
{
    class ShoppingDb : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public ShoppingDb() : base() { }
        public ShoppingDb(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("shopping");
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product")
                .HasKey(p => p.Id);

                entity.HasMany(e => e.OrderDetails)
                .WithOne(e => e.Product)
                .HasConstraintName("FK_Product_OrderDetail")
                .IsRequired(false);

                entity.Property(p => p.Name)
                .IsUnicode(true)
                .HasMaxLength(40)
                .IsRequired(false);

                entity.Property(p => p.Price)
                .HasPrecision(8, 3)
                .IsRequired(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order")
                .HasKey(p => p.Id);

                entity.Property(p => p.OrderTime)
                .HasColumnType("DateTime")
                .IsRequired(false);

                entity.Property(p => p.GrandTotal)
                .HasPrecision(8, 3)
                .IsRequired(false);

                entity.HasMany(e => e.OrderDetails)
                .WithOne(e => e.Order)
                .HasConstraintName("FK_Order_OrderDetail")
                .IsRequired(false);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OderDetail")
                .HasKey(p => p.Id);

                entity.Property(p => p.Price)
                .HasPrecision(8, 3)
                .IsRequired(false);

                entity.Property(p => p.SubTotal)
                .HasPrecision(8, 3)
                .IsRequired(false);

            });
        }
    }
}
