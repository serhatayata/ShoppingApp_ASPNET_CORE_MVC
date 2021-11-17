using ShoppingApp.Core.DataAccess.EntityFramework;
using ShoppingApp.Entity.Entities;
using ShoppingApp.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Repository.Concrete.EntityFramework
{
    public class EfOrderRepository:EfGenericRepository<Order,ShoppingAppContext>,IOrderRepository
    {

        public EfOrderRepository(ShoppingAppContext _context):base(_context)
        {
            
        }
    }
}
