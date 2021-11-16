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

        public IActionResult AddToCart(int productId, int quantity=1, bool isHome = false)      
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
                return RedirectToAction("Index","Home");
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
    }
}
