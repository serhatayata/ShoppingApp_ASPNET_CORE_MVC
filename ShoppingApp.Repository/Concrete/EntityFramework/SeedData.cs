using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingApp.Entity.Entities;

namespace ShoppingApp.Repository.Concrete.EntityFramework
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<ShoppingAppContext>();

            context.Database.Migrate();
            
            if (!context.Products.Any())
            {
                var products = new[]
                {
                    new Product(){ProductName="Product1",Price=500,Image="product1_thumb.jpg",isHome=true,isApproved=true,isFeatured=true},
                    new Product(){ProductName="Product2",Price=100,Image="product2_thumb.jpg",isHome=true,isApproved=true,isFeatured=true},
                    new Product(){ProductName="Product3",Price=200,Image="product3_thumb.jpg",isHome=true,isApproved=true,isFeatured=true},
                    new Product(){ProductName="Product4",Price=300,Image="product4_thumb.jpg",isHome=true,isApproved=true,isFeatured=true}
                };
                 
                context.Products.AddRange(products);
                var categories = new[]
                {
                    new Category(){CategoryName="Electronics"},
                    new Category(){CategoryName="Accessories"},
                    new Category(){CategoryName="Furniture"}
                };

                context.Categories.AddRange(categories);

                var productcategories = new[]
                {
                    new ProductCategory(){Product=products[0],Category=categories[0]},
                    new ProductCategory(){Product=products[1],Category=categories[1]},
                    new ProductCategory(){Product=products[2],Category=categories[2]},
                    new ProductCategory(){Product=products[3],Category=categories[1]},
                };

                context.AddRange(productcategories);

                context.SaveChanges();
            }
        }
    }
}
