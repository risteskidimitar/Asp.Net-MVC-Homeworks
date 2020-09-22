using ASP.NET.Homework03.DataLayer.Domain;
using ASP.NET.Homework03.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASP.NET.Homework03.DataLayer.Repositories
{
    public class OrderRepository : IGenericRepository<OrderDetails>
    {
        public List<OrderDetails> GetAll()
        {
            return CacheMovieDatabase.Orders;
        }

        public void AddEntity(OrderDetails entity)
        {
            CacheMovieDatabase.OrderId++;
            entity.Id = CacheMovieDatabase.OrderId;
            CacheMovieDatabase.Orders.Add(entity);
        }

        public OrderDetails GetById(int id)
        {
            return CacheMovieDatabase.Orders.FirstOrDefault(o => o.Id == id);
        }
    }
}
