using ASP.NET.Homework02_StoreApp.Models.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET.Homework02_StoreApp.Models.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public Genre Genre { get; set; }
        public bool MacedonianSubtitle { get; set; }
        public int ReleaseDate { get; set; }
        public float Rating { get; set; }
        public int Duration { get; set; }
        public string Link { get; set; }
    }
}
