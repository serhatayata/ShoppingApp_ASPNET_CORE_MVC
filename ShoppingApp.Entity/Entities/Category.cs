using ShoppingApp.Core.Entities;
using ShoppingApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Entity.Entities
{
    public class Category:IEntity
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
