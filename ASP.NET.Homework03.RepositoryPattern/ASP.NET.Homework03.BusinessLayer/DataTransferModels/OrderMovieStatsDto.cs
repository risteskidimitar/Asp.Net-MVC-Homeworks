using System;
using System.Collections.Generic;
using System.Text;

namespace ASP.NET.Homework03.BusinessLayer.DataTransferModels
{
    public class OrderMovieStatsDto
    {
        public int OrderId { get; set; }
        public UserDto User { get; set; }
        public MovieDto Movie { get; set; }
    }
}
