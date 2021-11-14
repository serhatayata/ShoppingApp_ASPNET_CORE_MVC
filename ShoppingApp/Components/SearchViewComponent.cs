using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp.Components
{
    public class SearchViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
