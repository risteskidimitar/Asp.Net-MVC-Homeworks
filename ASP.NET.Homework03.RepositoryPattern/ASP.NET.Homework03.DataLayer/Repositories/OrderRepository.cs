using ASP.NET.Homework03.DataLayer.Domain;
using ASP.NET.Homework03.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASP.NET.Homework03.DataLayer.Repositories
{
    public class OrderRepository : IGenericRepository<OrderMovieStatsHistory>
    {
        public List<OrderMovieStatsHistory> GetAll()
        {
            return MovieDatabase.Orders;
        }

        public void AddEntity(OrderMovieStatsHistory entity)
        {
            MovieDatabase.OrderId++;
            entity.Id = MovieDatabase.OrderId;
            MovieDatabase.Orders.Add(entity);
        }

        public OrderMovieStatsHistory GetById(int id)
        {
            return MovieDatabase.Orders.FirstOrDefault(o => o.Id == id);
        }
    }
}
