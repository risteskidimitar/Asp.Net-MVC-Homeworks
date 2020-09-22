using ASP.NET.Homework03.DataLayer.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ASP.NET.Homework03.DataLayer.Domain
{
    public class Movie 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public Genre Genre { get; set; }
        public bool HasMacedonianSubtitle { get; set; }
        public int ReleaseDate { get; set; }
        public float Rating { get; set; }
        public int Duration { get; set; }
        public string Link { get; set; }
        public List<OrderDetails> Orders { get; set; }
    }
}
