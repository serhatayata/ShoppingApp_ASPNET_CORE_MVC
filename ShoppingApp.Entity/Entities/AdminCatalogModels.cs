using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Entity.Entities
{
    public class AdminEditCategoryModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public List<AdminEditCategoryProduct> Products { get; set; }
    }

    public class AdminEditCategoryProduct
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public bool IsFeatured { get; set; }
    }
}
