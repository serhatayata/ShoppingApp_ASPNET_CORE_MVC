using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryRepository catRepository;
        public CategoryController(ICategoryRepository _catRepository)
        {
            catRepository = _catRepository;
        }
        public IActionResult Index()
        {
            return View(catRepository.GetByName("Electronics"));
        }
    }
}
