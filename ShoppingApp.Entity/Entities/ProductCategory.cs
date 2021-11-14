using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Entity.Entities
{
    public class ProductCategory
    {
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}
