using ASP.NET.Homework03.BusinessLayer.Helper;
using ASP.NET.Homework03.BusinessLayer.Interfaces;
using ASP.NET.Homework03.BusinessLayer.ViewModels;
using ASP.NET.Homework03.DataLayer.Domain;
using ASP.NET.Homework03.DataLayer.Domain.Enum;
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
        public readonly IGenericRepository<Movie> _movieRepository;
        public readonly IGenericRepository<OrderMovieStatsHistory> _orderRepository;
        public readonly IGenericRepository<User> _userRepository;
        public MovieService()
        {
            _movieRepository = new MovieRepository();
            _orderRepository = new OrderRepository();
            _userRepository = new UserRepository();

        }
        public List<MovieDetailsVM> GetAllMovies()
        {
            return _movieRepository.GetAll().Select(m => new MovieDetailsVM
            { Id = m.Id, Duration = m.Duration, Link = m.Link, Price = m.Price, Genre = m.Genre, Rating = m.Rating, ReleaseDate = m.ReleaseDate, Title = m.Title }).ToList();
        }

        public HelperClass MovieById(OrderDetailsVM orderDetails)
        {
            var movie = _movieRepository.GetById(orderDetails.IdOfMovie);
            var helper = new HelperClass();
            helper.OrderDetailsVM = orderDetails;

            if (movie == null)
            {
                helper.Message = "There is no movie like that, try again";
                return helper;
            }

            var user = new User()
            {
                FirstName = orderDetails.FirstName,
                LastName = orderDetails.LastName,
                Email = orderDetails.Email,
                Phone = orderDetails.Phone
            };

            if (string.IsNullOrEmpty(user.Email))
            {
                helper.Message = "You must have valid email";
                return helper;
            }

            if (_userRepository.GetAll()
                .SingleOrDefault(u => u.Email.ToLower().Trim() == user.Email.ToLower().Trim()) == null)
            {
                _userRepository.AddEntity(user);
            }
            var stats = new OrderMovieStatsHistory()
            {
                MovieId = movie.Id,
                UserId = user.Id
            };
            _orderRepository.AddEntity(stats);

            return helper;
        }

        public HelperClass UploadMovie(UploadMovieVM uploadMovieVM)
        {
            var helper = new HelperClass();
            helper.UploadMovieVM = uploadMovieVM;
            var allUsers = _userRepository.GetAll();
            var allMovies = _movieRepository.GetAll();


            if (string.IsNullOrWhiteSpace(uploadMovieVM.Email))
            {
                helper.Message = "Enter correnct Email";
                return helper;
            }
            var oldUser = allUsers.FirstOrDefault(u => u.Email.ToLower().Trim() == uploadMovieVM.Email.ToLower().Trim());
            if (oldUser == null)
            {
                helper.Message = "You are Email is not correct";
                return helper;
            }
            if (oldUser.TypeOfUser != TypeOfUser.AdminUser)
            {
                helper.Message = "You are not Admin";
                return helper;
            }


            if (string.IsNullOrWhiteSpace(uploadMovieVM.Title))
            {
                helper.Message = "Enter Title";
                return helper;

            }

            var oldmovie = allMovies.FirstOrDefault(m => m.Title.ToLower().Trim() == uploadMovieVM.Title.ToLower().Trim());
            if (oldmovie != null)
            {
                helper.Message = "The movie is already uploaded... exists"; ;
                return helper;
            }
            // TODO mi go pamti filmot BUG

            var newMovie = new Movie()
            {
                Title = uploadMovieVM.Title,
                Duration = uploadMovieVM.Duration,
                Genre = uploadMovieVM.Genre,
                Link = uploadMovieVM.Link,
                MacedonianSubtitle = uploadMovieVM.MacedonianSubtitle,
                Price = uploadMovieVM.Price,
                Rating = uploadMovieVM.Rating,
                ReleaseDate = uploadMovieVM.ReleaseDate,
            };

            _movieRepository.AddEntity(newMovie);
            return helper;

        }
    }
}