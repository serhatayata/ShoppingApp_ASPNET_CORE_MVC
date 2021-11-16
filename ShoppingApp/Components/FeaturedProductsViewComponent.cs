using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp.Components
{
    public class FeaturedProductsViewComponent:ViewComponent
    {
        private IProductRepository repository;
        public FeaturedProductsViewComponent(IProductRepository _repository)
        {
            repository = _repository;
        }

        public IViewComponentResult Invoke()
        {
           return  View(repository.GetAll().Where(x=>x.IsApproved && x.IsFeatured==true).ToList());
        }

    }
}
