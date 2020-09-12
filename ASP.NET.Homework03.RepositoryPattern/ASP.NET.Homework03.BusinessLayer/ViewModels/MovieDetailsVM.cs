using ASP.NET.Homework03.DataLayer.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASP.NET.Homework03.BusinessLayer.ViewModels
{
    public class MovieDetailsVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public double Price { get; set; }
        public int ReleaseDate { get; set; }
        public float Rating { get; set; }
        public int Duration { get; set; }
        public string Link { get; set; }
    }
}
