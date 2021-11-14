using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp.Components
{
    public class CategoryMenuViewComponent:ViewComponent
    {
        public ICategoryRepository repository;
        public CategoryMenuViewComponent(ICategoryRepository _repository)
        {
            repository = _repository;
        }

        public IViewComponentResult Invoke()
        {
            return View(repository.GetAllWithProductCount());
        }

    }
}
