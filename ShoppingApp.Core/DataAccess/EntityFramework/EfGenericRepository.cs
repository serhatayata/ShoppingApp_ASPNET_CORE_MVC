using Microsoft.EntityFrameworkCore;
using ShoppingApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Core.DataAccess.EntityFramework
{
    public class EfGenericRepository<T,TContext> : IGenericRepository<T> 
        where T : class,IEntity,new()
        where TContext:DbContext,new()
    {
        public void Add(T entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Edit(T entity)
        {
            using (TContext context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
            }
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            using (TContext context = new TContext())
            {
                return context.Set<T>().Where(predicate);
            }
        }

        public T Get(int id)
        {
            using (TContext context = new TContext())
            {
                return context.Set<T>().Find(id);
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (TContext context = new TContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public void Save()
        {
            using (TContext context = new TContext())
            {
                context.SaveChanges();
            }
        }
    }
}
