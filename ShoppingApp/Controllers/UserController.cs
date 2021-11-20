using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Entity.Entities;
using ShoppingApp.Repository.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp.Controllers
{
    [Authorize(Roles ="user")]
    public class UserController : Controller
    {
        private readonly ShoppingAppContext db;
        public UserController(ShoppingAppContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            var orders = db.Orders.Where(x => x.Username == User.Identity.Name)
                       .Include(x=>x.OrderLines)
                       .ThenInclude(y=>y.Product).ToList();
            return View(orders);
        }
    }
}
