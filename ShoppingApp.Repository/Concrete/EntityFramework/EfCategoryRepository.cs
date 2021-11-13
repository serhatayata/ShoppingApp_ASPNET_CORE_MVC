using Microsoft.EntityFrameworkCore;
using ShoppingApp.Core.DataAccess.EntityFramework;
using ShoppingApp.Core.Entities;
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
    public class EfCategoryRepository : EfGenericRepository<Category,ShoppingAppContext>, ICategoryRepository
    {
        private readonly ShoppingAppContext context;

        public EfCategoryRepository(ShoppingAppContext _context)
        {
            context = _context;
        }
        public Category GetByName(string name) 
        {
            return context.Categories.Where(x => x.CategoryName == name).FirstOrDefault();
        }




    }
}
