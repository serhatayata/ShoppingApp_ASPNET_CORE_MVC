using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingApp.Entity.Entities;
using ShoppingApp.Models;
using ShoppingApp.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository proRepository;
        private IUnitOfWork uowRepository;
        public HomeController(IProductRepository _proRepository,IUnitOfWork _uowRepository)
        {
            proRepository = _proRepository;
            uowRepository = _uowRepository;
        }
        public IActionResult Index()
        {
            return View(uowRepository.Products.GetAll().Where(x=>x.IsApproved && x.IsHome));
        }
        public IActionResult Details(int id)
        {
            return View(proRepository.Get(id));
        }
        public IActionResult Create()
        {
            var prd = new Product() { ProductName = "deneme", Price = 500 };
            uowRepository.Products.Add(prd);
            uowRepository.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
