using ASP.NET.Homework02_StoreApp.Models.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET.Homework02_StoreApp.Models.ViewModels
{
    public class UploadMovieVM
    {
        [Display(Name = "Enter your email if you are Admin")]
        public string Email { get; set; }

        public int Id { get; set; }

        [Display(Name = "Title of Movie")]
        public string Title { get; set; }

        [Display(Name = "Enter price in MKD")]
        public double Price { get; set; }
        public Genre Genre { get; set; }

        [Display(Name = "Macedonian subtitele is included?")]
        public bool MacedonianSubtitle { get; set; }

        [Display(Name = "Year of release")]
        public int ReleaseDate { get; set; }

        [Display(Name = "IMDB rating is")]
        public float Rating { get; set; }

        [Display(Name = "Duration in minutes")]
        public int Duration { get; set; }
        [Display(Name = "IMDB link")]
        public string Link { get; set; }
    }
}
