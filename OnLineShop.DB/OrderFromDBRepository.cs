using Microsoft.EntityFrameworkCore;
using OnLineShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnLineShop.DB
{
    public class OrderFromDBRepository : IGetOrders
    {
        private readonly DatabaseContext _dbContext;
        public OrderFromDBRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<OrderDB> GetOrderDBs()
        {
            return _dbContext.orderDBs.ToList();
        }
        public OrderDB TryGetOrderById(Guid id)
        {
            return _dbContext.orderDBs.Include(x => x.Cart).ThenInclude(x => x.Products).ThenInclude(x => x.Product).FirstOrDefault(x => x.Id == id);
        }
        public void AddOrder(OrderDB newOrder)
        {
            _dbContext.orderDBs.Add(newOrder);
            _dbContext.SaveChanges();
        }
    }

    public interface IGetOrders
    {
        public List<OrderDB> GetOrderDBs();
        public void AddOrder(OrderDB newOrder);
        public OrderDB TryGetOrderById(Guid id);
    }
}
