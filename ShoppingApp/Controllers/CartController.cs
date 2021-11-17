using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Entity.Entities;
using ShoppingApp.Infrastructure;
using ShoppingApp.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository proRepository;
        public CartController(IProductRepository _proRepository)
        {
            proRepository = _proRepository;
        }


        public IActionResult Index()
        {
            return View(GetCart());
        }
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity = 1, bool isHome = false)
        {
            var product = proRepository.Get(productId);
            if (product != null)
            {
                var cart = GetCart();

                cart.AddProduct(product, quantity);

                SaveCart(cart);
            }
            if (isHome)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult UpdateCart(int productId, int quantity = 1, bool isHome = false)
        {
            var product = proRepository.Get(productId);
            if (product != null)
            {
                var cart = GetCart();

                cart.UpdateProduct(product, quantity);

                SaveCart(cart);
            }
            if (isHome)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public IActionResult RemoveFromCart(int ProductId)
        {
            var product = proRepository.Get(ProductId);
            if (product != null)
            {
                var cart = GetCart();
                cart.RemoveProduct(product);
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJSON("Cart", cart);
        }
        private Cart GetCart()
        {
            return HttpContext.Session.GetJSON<Cart>("Cart") ?? new Cart();
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(OrderDetails model)
        {
            var cart = GetCart();
            if (cart.Products.Count == 0)
            {
                ModelState.AddModelError("", "There is no product in the cart");
            }
            if (ModelState.IsValid)
            {
                SaveOrder(cart, model);
                cart.ClearAll();
                return View("Completed");
            }
            return View(model);
        }
        [NonAction]
        private void SaveOrder(Cart cart, OrderDetails details)
        {
            var order = new Order()
            {
                OrderNumber = "A" + (new Random()).Next(11111, 99999).ToString(),
                Total = cart.TotalPrice(),
                OrderDate = DateTime.Now,
                OrderState = EnumOrderState.Waiting,
                Username = User.Identity.Name,
                AddressTitle = details.AddressTitle,
                Address = details.Address,
                City = details.City,
                Neighborhood = details.Neighborhood,
                Phone = details.Phone
            };
            //OrderLines was created with constructor in Order
            foreach (var product in cart.Products)
            {
                var orderline = new OrderLine()
                {
                    Quantity = product.Quantity,
                    Price = product.Product.Price,
                    ProductID = product.Product.ProductID,
                };
                order.OrderLines.Add(orderline);
            }


        }
    }
}
