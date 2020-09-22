using ASP.NET.Homework03.BusinessLayer.DataTransferModels;
using ASP.NET.Homework03.BusinessLayer.Helper;
using ASP.NET.Homework03.BusinessLayer.Interfaces;
using ASP.NET.Homework03.DataLayer.Domain;
using ASP.NET.Homework03.DataLayer.Interfaces;
using ASP.NET.Homework03.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ASP.NET.Homework03.BusinessLayer.Services
{
    public class JsonOrdersService : IJsonOrders
    {

        public readonly IGenericRepository<Movie> _movieRepository;
        public readonly IGenericRepository<OrderDetails> _orderRepository;
        public readonly IGenericRepository<User> _userRepository;

        public JsonOrdersService(IGenericRepository<Movie> movieRepository,
            IGenericRepository<OrderDetails> orderRepository, IGenericRepository<User> userRepository)
        {
            _movieRepository = movieRepository;
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public List<OrderMovieStatsDto> JsonOrders()
        {
            var orders = _orderRepository.GetAll();
            var listOfOrdersDto = new List<OrderMovieStatsDto>();
            foreach (var order in orders)//TODO : orders.Select(o=> new ...)
            {
                var movie = _movieRepository.GetAll().FirstOrDefault(m => m.Id == order.MovieId);
                var user = _userRepository.GetAll().FirstOrDefault(u => u.Id == order.UserId);

                var satsDto = MapperHelper.MapOrderToOrderMovieStatsDtoModel(order, movie, user);
                listOfOrdersDto.Add(satsDto);
            }

            return listOfOrdersDto;
        }
    }
}
