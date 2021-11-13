using Microsoft.EntityFrameworkCore;
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
    public class EfOrderRepository : IOrderRepository
    {
        private ShoppingAppContext context;
        public EfOrderRepository(ShoppingAppContext _context)
        {
            context = _context;
        }
        public void Add(Order entity)
        {
            context.Orders.Add(entity);
        }

        public void Delete(Order entity)
        {
            context.Orders.Remove(entity);
        }

        public void Edit(Order entity)
        {
            context.Entry<Order>(entity).State = EntityState.Modified;
        }

        public IEnumerable<Order> Find(Expression<Func<Order, bool>> predicate)
        {
            return context.Orders.Where(predicate);
        }

        public Order Get(int id)
        {
            return context.Orders.FirstOrDefault(i=>i.OrderID==id);
        }

        public IEnumerable<Order> GetAll()
        {
            return context.Orders;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
