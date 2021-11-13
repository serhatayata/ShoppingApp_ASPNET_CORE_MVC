using ShoppingApp.Core.DataAccess.EntityFramework;
using ShoppingApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Repository.Abstract
{
    public interface IOrderRepository:IGenericRepository<Order>
    {

    }
}
