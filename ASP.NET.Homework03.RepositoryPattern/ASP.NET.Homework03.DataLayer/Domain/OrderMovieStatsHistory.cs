using System;
using System.Collections.Generic;
using System.Text;

namespace ASP.NET.Homework03.DataLayer.Domain
{
   public class OrderMovieStatsHistory : BaseEntity
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }
}
