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
                entity.ToTable("Product")
                .HasKey(p => p.Id);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order")
                .HasKey(p => p.Id);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OderDetail")
                .HasKey(p => p.Id);
            });
        }
    }
}
