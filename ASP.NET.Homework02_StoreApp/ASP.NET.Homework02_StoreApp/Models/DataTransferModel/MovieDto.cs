using ASP.NET.Homework02_StoreApp.Models.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ASP.NET.Homework02_StoreApp.Models.DataAccessModels
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
