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
        public MovieService(IGenericRepository<Movie> movieRepository,
            IGenericRepository<OrderMovieStatsHistory> orderRepository, IGenericRepository<User> userRepository)
        {
            _movieRepository = movieRepository;
            _orderRepository = orderRepository;
            _userRepository = userRepository;

        }
        public List<MovieDetailsVM> GetAllMovies()
        {
            var allMovies = _movieRepository.GetAll();
            return MapperHelper.MapMovieModelsToMovieDetailsVm(allMovies);
        }

        public ResultsWrapperHelper MovieById(OrderDetailsVM orderDetails)
        {
            var movie = _movieRepository.GetById(orderDetails.IdOfMovie);
            var helper = new ResultsWrapperHelper();
            helper.OrderDetailsVM = orderDetails;

            if (movie == null)
            {
                helper.Message = "There is no movie like that, try again";
                return helper;
            }

            var user = MapperHelper.MapOrderDetailsVmToUserModel(orderDetails);

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

        public ResultsWrapperHelper UploadMovie(UploadMovieVM uploadMovieVM)
        {
            var helper = new ResultsWrapperHelper();
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

            var newMovie = MapperHelper.MapUploadMovieVmToMovieModel(uploadMovieVM);

            _movieRepository.AddEntity(newMovie);

            return helper;

        }
    }
}