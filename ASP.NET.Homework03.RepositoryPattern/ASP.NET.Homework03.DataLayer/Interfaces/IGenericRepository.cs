using ASP.NET.Homework03.DataLayer.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASP.NET.Homework03.DataLayer.Interfaces
{
    public interface IGenericRepository <T> 
    {
        List<T> GetAll();

        void AddEntity(T entity);

        T GetById(int id);

    }
}
