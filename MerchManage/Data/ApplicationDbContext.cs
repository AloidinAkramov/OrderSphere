using MerchManage.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MerchManage.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Customer 
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers");
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(x => x.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(x => x.RegisteredOn)
                    .HasColumnType("timestamp without time zone");

                //Orderga ulash
                entity.HasMany(c => c.Orders)
                    .WithOne(o => o.Customer)
                    .HasForeignKey(o => o.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            
            //Order
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");
                entity.HasKey(x => x.Id);

                entity.Property(x => x.OrderDate)
                    .HasColumnType("timestamp without time zone");

                entity.Property(x => x.TotalAmount)
                    .IsRequired()
                    .HasColumnType("numerc(10,3)");

                // Order detailga ulash
                entity.HasMany(o => o.orderDetails)
                     .WithOne(od => od.Order)
                     .HasForeignKey(od => od.OrderId)
                     .OnDelete(DeleteBehavior.Cascade);
            });

            //Prodeuct
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(x => x.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(x => x.Price)
                  .HasColumnType("numeric(10,2)");

                //Order detailga ulash
                entity.HasMany(p => p.orderDetails)
                   .WithOne(od => od.Product)
                   .HasForeignKey(od => od.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
            });

            //Order detail 
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(x => x.Quantity);
                entity.Property(x => x.Price)
                    .HasColumnType("numerc(10,3)");
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}