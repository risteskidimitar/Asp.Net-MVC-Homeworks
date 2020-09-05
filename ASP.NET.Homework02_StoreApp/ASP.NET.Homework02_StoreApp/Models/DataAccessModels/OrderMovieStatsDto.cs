using ASP.NET.Homework02_StoreApp.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET.Homework02_StoreApp.Models.DataAccessModels
{
    public class OrderMovieStatsDto
    {
        public int OrderId { get; set; }
        public UserDto User { get; set; }
        public MovieDto Movie { get; set; }
    }
}
