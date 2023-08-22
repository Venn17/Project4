using Microsoft.EntityFrameworkCore;
using Project4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project4.Services
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Set Idenity for primary key
            modelBuilder.Entity<Restaurants>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Carts>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Historys>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Locals>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Coupons>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Sizes>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Toppings>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Logined>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Carts> Carts { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Coupons> Coupons { get; set; }
        public DbSet<Historys> Historys { get; set; }
        public DbSet<Locals> Locals { get; set; }
        public DbSet<Sizes> Sizes { get; set; }
        public DbSet<Toppings> Toppings { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Restaurants> Restaurants { get; set; }
        public DbSet<Logined> Logineds { get; set; }
    }
}
