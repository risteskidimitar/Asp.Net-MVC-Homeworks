using ASP.NET.Homework03.DataLayer.Domain;
using ASP.NET.Homework03.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASP.NET.Homework03.DataLayer.Repositories
{
    public class UserRepository : IGenericRepository<User>
    {
        public List<User> GetAll()
        {
            return CacheMovieDatabase.Users;
        }

        public void AddEntity(User entity)
        {
            CacheMovieDatabase.UserId++;
            entity.Id = CacheMovieDatabase.UserId;
            CacheMovieDatabase.Users.Add(entity);
        }


        public User GetById(int id)
        {
            return CacheMovieDatabase.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
