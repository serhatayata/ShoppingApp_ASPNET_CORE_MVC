using ShoppingApp.Core.Entities;
using ShoppingApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Entity.Entities
{
    public class Product:IEntity
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public bool isApproved { get; set; }
        public bool isHome { get; set; }
        public bool isFeatured { get; set; }
        public virtual List<ProductCategory> ProductCategories { get; set; }
    }
}
