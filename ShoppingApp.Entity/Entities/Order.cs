using ShoppingApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Entity.Entities
{
    public class Order:IEntity
    {
        public int OrderID { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
