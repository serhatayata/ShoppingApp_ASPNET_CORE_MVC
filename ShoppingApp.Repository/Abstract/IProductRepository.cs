using ShoppingApp.Core.DataAccess.EntityFramework;
using ShoppingApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Repository.Abstract
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        List<Product> GetTop5Products();
    }
}
