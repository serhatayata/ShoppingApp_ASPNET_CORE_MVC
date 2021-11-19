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
        [Required]
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string HtmlContent { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public bool IsFeatured { get; set; }
        public virtual List<ProductCategory> ProductCategories { get; set; } 
        public virtual List<Image> Images { get; set; }
        public virtual List<ProductAttribute> Attributes { get; set; }
    }
}
