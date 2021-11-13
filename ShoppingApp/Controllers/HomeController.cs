using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public HomeController(IProductRepository _proRepository)
        {
            proRepository = _proRepository;
        }
        public IActionResult Index()
        {
            var x = proRepository.GetAll();
            return View(proRepository.GetAll());
        }
        public IActionResult Details(int id)
        {
            return View(proRepository.Get(id));
        }
    }
}
