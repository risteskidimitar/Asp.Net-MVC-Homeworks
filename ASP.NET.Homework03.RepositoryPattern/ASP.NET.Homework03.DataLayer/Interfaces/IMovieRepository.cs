using ASP.NET.Homework03.DataLayer.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASP.NET.Homework03.DataLayer.Interfaces
{
    public interface IMovieRepository<T> where T : IBaseEntity
    {
        List<T> GetAll();

        void AddEnity(T entity);

        T GetById(int id);

    }
}
