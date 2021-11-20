using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Entity.Entities;
using ShoppingApp.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository proRepository;
        public int pageSize = 3;
        public ProductController(IProductRepository _proRepository)
        {
            proRepository = _proRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List(string category,string prd="",int page=1)
        {
            if (prd==null)
            {
                prd = "";
            }
            var products = proRepository.GetAll().Where(x=>x.ProductName.Contains(prd));
            if (!string.IsNullOrEmpty(category))
            {
                products = products.Include(x => x.ProductCategories)
                                    .ThenInclude(i => i.Category)
                                    .Where(y => y.ProductCategories.Any(a => a.Category.CategoryName == category));
            }
            var count = products.Count();
            products = products.Skip((page-1)*pageSize).Take(pageSize);
            return View(
                new ProductListModel()
                {
                    Products = products,
                    PagingInfo=new PagingInfo()
                    {
                        CurrentPage=page,
                        ItemsPerPage=pageSize,
                        TotalItems=count
                    }
                });
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(
                proRepository.GetAll()
                .Where(i=>i.ProductID==id)
                .Include(a=>a.Images)
                .Include(b=>b.Attributes)
                .Include(x=>x.ProductCategories)
                .ThenInclude(y=>y.Category)
                .Select(i=> new ProductDetailsModel()
                {
                    Product=i,
                    ProductImages=i.Images,
                    ProductAttributes=i.Attributes,
                    Categories=i.ProductCategories.Select(a=>a.Category).ToList()
                }).FirstOrDefault());
        }
    }
}
