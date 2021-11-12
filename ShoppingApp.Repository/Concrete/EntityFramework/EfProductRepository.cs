using ShoppingApp.Entity.Entity;
using ShoppingApp.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Repository.Concrete.EntityFramework
{
    public class EfProductRepository : IProductRepository
    {
        private ShoppingAppContext context;
        public EfProductRepository(ShoppingAppContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Product> Products => context.Products;
    }
}
