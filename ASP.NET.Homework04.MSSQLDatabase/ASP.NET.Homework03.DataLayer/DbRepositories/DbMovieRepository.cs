using ASP.NET.Homework03.DataLayer.Domain;
using ASP.NET.Homework03.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASP.NET.Homework03.DataLayer.DbRepositories
{
    public class DbMovieRepository : IGenericRepository<Movie>
    {
        private readonly MovieAppContext _context;
        public DbMovieRepository(MovieAppContext context)
        {
            _context = context;
        }

        public List<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public void AddEntity(Movie entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public Movie GetById(int id)
        {
            return _context.Movies.FirstOrDefault(m => m.Id == id);
        }
    }
}
