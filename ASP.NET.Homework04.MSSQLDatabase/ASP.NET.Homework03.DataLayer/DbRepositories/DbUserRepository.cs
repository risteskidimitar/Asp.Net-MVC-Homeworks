using ASP.NET.Homework03.DataLayer.Domain;
using ASP.NET.Homework03.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASP.NET.Homework03.DataLayer.DbRepositories
{
    public class DbUserRepository : IGenericRepository<User>
    {
        private readonly MovieAppContext _context;
        public DbUserRepository(MovieAppContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void AddEntity(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }


        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}

