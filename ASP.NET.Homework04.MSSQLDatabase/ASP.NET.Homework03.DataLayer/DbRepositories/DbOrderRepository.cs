using ASP.NET.Homework03.DataLayer.Domain;
using ASP.NET.Homework03.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASP.NET.Homework03.DataLayer.DbRepositories
{
    public class DbOrderRepository : IGenericRepository<OrderDetails>
    {
        private readonly MovieAppContext _context;

        public DbOrderRepository(MovieAppContext context)
        {
            _context = context;
        }

        public List<OrderDetails> GetAll()
        {
            return _context.Orders
                .Include(x => x.User)
                .Include(x => x.Movie)
                .ToList();
        }

        public OrderDetails GetById(int id)
        {
            return _context.Orders
                .Include(i => i.User)
                .Include(i => i.Movie)
                .FirstOrDefault(x => x.Id == id);
        }

        public void AddEntity(OrderDetails entity)
        {
            _context.Orders.Add(entity);
            _context.SaveChanges();
        }
    }
}
