using Microsoft.EntityFrameworkCore;
using ShoppingApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Repository.Concrete.EntityFramework
{
    public class ShoppingAppContext:DbContext
    {
        public ShoppingAppContext()
        {

        }
        public ShoppingAppContext(DbContextOptions<ShoppingAppContext> options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-34G34T7\\SQLEXPRESS01;Initial Catalog=ShoppingAppDB;Integrated Security=True", y => y.MigrationsAssembly("ShoppingApp.Repository"));
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasKey(pk=>new { pk.ProductID,pk.CategoryID} );
        }

    }
}
