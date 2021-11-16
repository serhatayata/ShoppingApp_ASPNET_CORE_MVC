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
                    new Product(){ProductName="Product1",Price=500,Image="product1.jpg",IsHome=true,IsApproved=true,IsFeatured=true,Description="Description Product 1" , HtmlContent="Html Content Product 1", DateAdded=DateTime.Now.AddDays(-10)},
                    new Product(){ProductName="Product2",Price=100,Image="product2.jpg",IsHome=true,IsApproved=true,IsFeatured=true,Description="Description Product 2" , HtmlContent="Html Content Product 2", DateAdded=DateTime.Now.AddDays(-12)},
                    new Product(){ProductName="Product3",Price=200,Image="product3.jpg",IsHome=true,IsApproved=true,IsFeatured=true,Description="Description Product 3" , HtmlContent="Html Content Product 3", DateAdded=DateTime.Now.AddDays(-15)},
                    new Product(){ProductName="Product4",Price=300,Image="product4.jpg",IsHome=true,IsApproved=true,IsFeatured=true,Description="Description Product 4" , HtmlContent="Html Content Product 4", DateAdded=DateTime.Now.AddDays(-1)}
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

                var images = new[]
                {
                    new Image(){ImageName="product1.jpg",Product=products[0]},
                    new Image(){ImageName="product3.jpg",Product=products[0]},
                    new Image(){ImageName="product4.jpg",Product=products[0]},

                    new Image(){ImageName="product1.jpg",Product=products[1]},
                    new Image(){ImageName="product3.jpg",Product=products[1]},
                    new Image(){ImageName="product4.jpg",Product=products[1]},

                    new Image(){ImageName="product1.jpg",Product=products[2]},
                    new Image(){ImageName="product3.jpg",Product=products[2]},
                    new Image(){ImageName="product4.jpg",Product=products[2]},

                    new Image(){ImageName="product1.jpg",Product=products[3]},
                    new Image(){ImageName="product3.jpg",Product=products[3]},
                    new Image(){ImageName="product4.jpg",Product=products[3]},

                };

                context.Images.AddRange(images);

                var attributes = new[]
                {
                    new ProductAttribute(){Attribute="Display",Value="15.6",Product=products[0]},
                    new ProductAttribute(){Attribute="Processor",Value="Intel",Product=products[0]},
                    new ProductAttribute(){Attribute="RAM Memory",Value="8GB",Product=products[0]},
                    new ProductAttribute(){Attribute="Hard Disk",Value="1TB",Product=products[0]},
                    new ProductAttribute(){Attribute="Color",Value="Black",Product=products[0]},

                    new ProductAttribute(){Attribute="Display",Value="15.6",Product=products[1]},
                    new ProductAttribute(){Attribute="Processor",Value="Intel",Product=products[1]},
                    new ProductAttribute(){Attribute="RAM Memory",Value="8GB",Product=products[1]},
                    new ProductAttribute(){Attribute="Hard Disk",Value="1TB",Product=products[1]},
                    new ProductAttribute(){Attribute="Color",Value="Black",Product=products[1]},

                    new ProductAttribute(){Attribute="Display",Value="15.6",Product=products[2]},
                    new ProductAttribute(){Attribute="Processor",Value="Intel",Product=products[2]},
                    new ProductAttribute(){Attribute="RAM Memory",Value="8GB",Product=products[2]},
                    new ProductAttribute(){Attribute="Hard Disk",Value="1TB",Product=products[2]},
                    new ProductAttribute(){Attribute="Color",Value="Black",Product=products[2]},

                    new ProductAttribute(){Attribute="Display",Value="15.6",Product=products[3]},
                    new ProductAttribute(){Attribute="Processor",Value="Intel",Product=products[3]},
                    new ProductAttribute(){Attribute="RAM Memory",Value="8GB",Product=products[3]},
                    new ProductAttribute(){Attribute="Hard Disk",Value="1TB",Product=products[3]},
                    new ProductAttribute(){Attribute="Color",Value="Black",Product=products[3]},

                };

                context.Attributes.AddRange(attributes);

                context.SaveChanges();
            }
        }
    }
}
