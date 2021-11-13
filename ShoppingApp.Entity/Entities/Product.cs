using ShoppingApp.Core.Entities;
using ShoppingApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Entity.Entities
{
    public class Product:IEntity
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
