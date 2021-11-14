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
    public class Category:IEntity
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public virtual List<ProductCategory> ProductCategories { get; set; }
    }
}
