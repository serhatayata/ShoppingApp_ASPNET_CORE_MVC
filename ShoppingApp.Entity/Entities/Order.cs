using ShoppingApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Entity.Entities
{
    public class Order:IEntity
    {
        public Order()
        {
            OrderLines = new List<OrderLine>();
        }

        [Key]
        public int OrderID { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }

        public string Username { get; set; }
        public string AddressTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Phone { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }
    }

    public enum EnumOrderState
    {
        [Display(Name="Waiting for validation")]
        Waiting,
        [Display(Name = "Order was completed")]
        Completed
    }
}
