using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Entity.Entities
{
    public class ProductDetailsModel
    {
        public Product Product { get; set; }
        public List<Image> ProductImages { get; set; }
        public List<ProductAttribute> ProductAttributes { get; set; }
        public List<Category> Categories { get; set; }
    }
}
