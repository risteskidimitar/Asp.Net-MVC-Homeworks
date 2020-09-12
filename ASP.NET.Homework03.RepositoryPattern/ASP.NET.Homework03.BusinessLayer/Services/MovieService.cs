using ASP.NET.Homework03.BusinessLayer.Interfaces;
using ASP.NET.Homework03.BusinessLayer.ViewModels;
using ASP.NET.Homework03.DataLayer.Domain;
using ASP.NET.Homework03.DataLayer.Interfaces;
using ASP.NET.Homework03.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASP.NET.Homework03.BusinessLayer.Services
{
    public class MovieService : IMovieService
    {
        public readonly IMovieRepository<Movie> _movieRepository;
        public readonly IMovieRepository<User> _userRepositry;
        public readonly IMovieRepository<OrderMovieStatsHistory> _orderRepositry;

        public MovieService()
        {
            _movieRepository = new MovieRepository<Movie>();
            _userRepositry = new MovieRepository<User>();
            _orderRepositry = new MovieRepository<OrderMovieStatsHistory>();
        }
        public List<MovieDetailsVM> GetAllMovies()
        {
            return _movieRepository.GetAll().Select(m => new MovieDetailsVM
            { Id = m.Id, Duration = m.Duration, Link = m.Link, Price = m.Price, Genre = m.Genre, Rating = m.Rating, ReleaseDate = m.ReleaseDate, Title = m.Title }).ToList();
        }

        public bool MovieById(OrderDetailsVM orderDetails)
        {
            var movie = _movieRepository.GetById(orderDetails.IdOfMovie);

            if (movie == null)
            {
                return false;
            }

            var user = new User()
            {
                Id = _userRepositry.GetAll().Count + 1,
                FirstName = orderDetails.FirstName,
                LastName = orderDetails.LastName,
                Email = orderDetails.Email,
                Phone = orderDetails.Phone
            };


            if (_userRepositry.GetAll()
                .SingleOrDefault(u => u.Email.ToLower().Trim() == user.Email.ToLower().Trim()) == null)
            {
                _userRepositry.AddEnity(user);
            }

            var stats = new OrderMovieStatsHistory()
            {
                Id = _orderRepositry.GetAll().Count + 1,
                MovieId = movie.Id,
                UserId = user.Id
            };

            _orderRepositry.AddEnity(stats);
            return true;
        }

        public string UploadMovie(UploadMovieVM uploadMovieVM)
        {
            var check = "ok";
            var allUsers = _userRepositry.GetAll();
            var allMovies = _movieRepository.GetAll();

            if (allUsers.FirstOrDefault(u => u.Email.ToLower().Trim() == uploadMovieVM.Email.ToLower().Trim()) == null)
            {
                return check = "admin";
            }
            if (allMovies.FirstOrDefault(m => m.Title.ToLower().Trim() == uploadMovieVM.Title.ToLower().Trim()) != null)
            {
                return check = "movie";
            }

            var newMovie = new Movie()
            {
                Id = _movieRepository.GetAll().Count + 1,
                Title = uploadMovieVM.Title,
                Duration = uploadMovieVM.Duration,
                Genre = uploadMovieVM.Genre,
                Link = uploadMovieVM.Link,
                MacedonianSubtitle = uploadMovieVM.MacedonianSubtitle,
                Price = uploadMovieVM.Price,
                Rating = uploadMovieVM.Rating,
                ReleaseDate = uploadMovieVM.ReleaseDate,
            };

            _movieRepository.AddEnity(newMovie);
            return check;
        }
    }
}