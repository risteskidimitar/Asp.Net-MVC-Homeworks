using ASP.NET.Homework03.DataLayer.Domain;
using ASP.NET.Homework03.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASP.NET.Homework03.DataLayer.Repositories
{
    public class MovieRepository : IGenericRepository<Movie>
    {

        public List<Movie> GetAll()
        {
            return CacheMovieDatabase.Movies;
        }

        public void AddEntity(Movie entity)
        {
            CacheMovieDatabase.MovieId++;
            entity.Id = CacheMovieDatabase.MovieId;
            CacheMovieDatabase.Movies.Add(entity);
        }


        public Movie GetById(int id)
        {
            return CacheMovieDatabase.Movies.FirstOrDefault(m => m.Id == id);
        }
    }
}
