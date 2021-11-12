using Microsoft.EntityFrameworkCore;
using ShoppingApp.Entity.Entities;
using ShoppingApp.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Repository.Concrete.EntityFramework
{
    public class ShoppingAppContext:DbContext
    {
        public ShoppingAppContext(DbContextOptions<ShoppingAppContext> options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasKey(pk=>new { pk.ProductID,pk.CategoryID} );
        }

    }
}
