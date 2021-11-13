using Microsoft.EntityFrameworkCore;
using ShoppingApp.Core.DataAccess.EntityFramework;
using ShoppingApp.Entity.Entities;
using ShoppingApp.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Repository.Concrete.EntityFramework
{
    public class EfProductRepository : EfGenericRepository<Product,ShoppingAppContext>,IProductRepository
    {
        private ShoppingAppContext context;
        public EfProductRepository(ShoppingAppContext ctx)
        {
            context = ctx;
        }

        public List<Product> GetTop5Products()
        {
            return context.Products.OrderByDescending(x => x.ProductID).Take(5).ToList();
        }
    }
}
