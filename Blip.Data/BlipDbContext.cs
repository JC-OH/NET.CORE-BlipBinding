using Blip.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Blip.Data
{
    public class BlipDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .EnableSensitiveDataLogging()
                .UseSqlServer(
                "Data Source = localhost; Initial Catalog=BlipBindingNetCore; Persist Security Info=True;User ID=test; Password=test;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().HasKey(s => new { s.ItemID, s.OrderID });
        }
    }

}
