using ASP.NET.Homework03.DataLayer.Domain;
using ASP.NET.Homework03.DataLayer.Domain.Enum;
using ASP.NET.Homework03.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASP.NET.Homework03.DataLayer.Repositories
{
    public class MovieRepository<T> : IMovieRepository<T> where T : IBaseEntity
    {
      
        public List<T> GetAll()
        {
            return MovieDatabase<T>.AllEntities;
        }


        public T GetById(int id)
        {
            return GetAll().FirstOrDefault(e => e.Id == id);
        }


        public void AddEnity(T entity)
        {
            GetAll().Add(entity);
        }



    }
}
