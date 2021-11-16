using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Entity.Entities;
using ShoppingApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp.Components
{
    public class CartSummaryViewComponent:ViewComponent
    {   
        public string Invoke()
        {
            return HttpContext.Session.GetJSON<Cart>("Cart")?.Products.Count().ToString() ?? "0";
        }
    }
}
