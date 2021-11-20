using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Entity.Entities;
using ShoppingApp.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp.Controllers
{
    //[Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private IUnitOfWork unitOfWork;
        public AdminController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CatalogList()
        {
            var model = new CatalogListModel()
            {
                Categories = unitOfWork.Categories.GetAll().ToList(),
                Products = unitOfWork.Products.GetAll().ToList()
            };
            return View(model);
        } 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory(Category entity)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Categories.Add(entity);
                unitOfWork.SaveChanges();

                return Ok(entity);
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var entity = unitOfWork.Categories.GetAll()
                       .Include(x => x.ProductCategories).ThenInclude(y => y.Product)
                       .Where(a => a.CategoryID == id)
                       .Select(x => new AdminEditCategoryModel()
                       {
                           CategoryID = x.CategoryID,
                           CategoryName = x.CategoryName,
                           Products = x.ProductCategories.Select(a => new AdminEditCategoryProduct()
                           {
                               ProductID = a.ProductID,
                               ProductName = a.Product.ProductName,
                               Image = a.Product.Image,
                               IsApproved = a.Product.IsApproved,
                               IsFeatured = a.Product.IsFeatured,
                               IsHome = a.Product.IsHome
                           }).ToList()
                       }).FirstOrDefault();
            return View(entity);
        }
        [HttpPost]
        public IActionResult EditCategory(Category entity)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Categories.Edit(entity);
                unitOfWork.SaveChanges();

                return RedirectToAction("CatalogList");
            }
            return RedirectToAction("EditCategory",entity.CategoryID);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveFromCategory(int CategoryID,int ProductID)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Categories.RemoveFromCategory(CategoryID, ProductID);
                unitOfWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
         
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(Product entity,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\products",file.FileName);
                    var path_tn = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\products\\tn",file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        entity.Image = file.FileName;
                    }
                    using (var stream = new FileStream(path_tn, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                entity.DateAdded = DateTime.Now;
                unitOfWork.Products.Add(entity);
                unitOfWork.SaveChanges();
                return RedirectToAction("CatalogList","Admin");
            }
            return View(entity);
        }


    }
}
