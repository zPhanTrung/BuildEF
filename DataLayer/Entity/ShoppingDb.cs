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
namespace DataLayer.Entity
{
    internal class ShoppingDb: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public ShoppingDb() : base() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Shopping");
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product")
                .HasKey(p => p.Id);

                entity.HasMany(e => e.OrderDetails)
                .WithOne(e => e.Product)
                .HasConstraintName("FK_Product_OrderDetail");

                entity.Property(p=>p.Name)
                .IsUnicode(true)
                .HasMaxLength(40)
                .IsRequired(false);

                entity.Property(p => p.Price)
                .HasPrecision(8,3)
                .IsRequired(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order")
                .HasKey(p => p.Id);

                entity.Property(p => p.OrderTime)
                .HasColumnType("DateTime");

                entity.Property(p => p.GrandTotal)
                .HasPrecision(8, 3);

                entity.HasMany(e => e.OrderDetails)
                .WithOne(e => e.Order)
                .HasConstraintName("FK_Order_OrderDetail");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OderDetail")
                .HasKey(p => p.Id);

                entity.Property(p => p.Price)
                .HasPrecision(8, 3);

                entity.Property(p => p.SubTotal)
                .HasPrecision(8, 3);

                entity.HasOne(e => e.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId)
                .HasConstraintName("FK_Product_OrderDetail");

                entity.HasOne(e => e.Order)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey(p => p.ProductId)
                .HasConstraintName("FK_Order_OrderDetail");
            });
        }
    }
}
