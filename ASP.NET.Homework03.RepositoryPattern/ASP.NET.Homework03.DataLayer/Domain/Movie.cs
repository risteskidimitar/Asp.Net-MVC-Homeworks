using ASP.NET.Homework03.DataLayer.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASP.NET.Homework03.DataLayer.Domain
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public Genre Genre { get; set; }
        public bool HasMacedonianSubtitle { get; set; }
        public int ReleaseDate { get; set; }
        public float Rating { get; set; }
        public int Duration { get; set; }
        public string Link { get; set; }
    }
}
