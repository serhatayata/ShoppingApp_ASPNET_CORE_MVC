using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Entity.Entities
{
    public class Image
    {
        [Key]
        public int ImageID { get; set; }
        public string ImageName { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
