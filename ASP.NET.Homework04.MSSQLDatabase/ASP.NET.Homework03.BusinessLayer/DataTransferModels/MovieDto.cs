using ASP.NET.Homework03.DataLayer.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace ASP.NET.Homework03.BusinessLayer.DataTransferModels
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Genre Genre { get; set; }
        public int ReleaseDate { get; set; }
        public float Rating { get; set; }
        public int Duration { get; set; }

    }
}
