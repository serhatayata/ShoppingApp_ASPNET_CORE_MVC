using ShoppingApp.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Repository.Concrete.EntityFramework
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly ShoppingAppContext context;
        public EfUnitOfWork(ShoppingAppContext _context)
        {
            context = _context ?? throw new ArgumentNullException("DbContext cannot be null!");
        }
        private IProductRepository _products;
        private ICategoryRepository _categories;
        public IProductRepository Products
        {
            get
            {
                return _products ?? (_products = new EfProductRepository(context));
            }
        }

        public ICategoryRepository Categories
        {
            get
            {
                return _categories ?? (_categories = new EfCategoryRepository(context));
            }
        }


        public int SaveChanges()
        {
            try
            {
                return context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
