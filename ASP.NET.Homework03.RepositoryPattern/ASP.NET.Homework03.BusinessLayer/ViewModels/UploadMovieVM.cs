﻿using ASP.NET.Homework03.DataLayer.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ASP.NET.Homework03.BusinessLayer.ViewModels
{
    public class UploadMovieVM
    {

        [Display(Name = "Enter your email if you are Admin")]
        public string Email { get; set; }

        public int Id { get; set; }

        [Display(Name = "Title of Movie")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Price is required - custom")]
        [Display(Name = "Enter price in MKD")]
        public double Price { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Macedonian subtitele is included?")]
        public bool MacedonianSubtitle { get; set; }

        [Required(ErrorMessage = "year is required - custom")]
        [Display(Name = "Year of release")]
        public int ReleaseDate { get; set; }
        [Required(ErrorMessage = "Rating is required - custom")]
        [Display(Name = "IMDB rating is")]
        public float Rating { get; set; }
        [Required(ErrorMessage = "Duration is required - custom")]
        [Display(Name = "Duration in minutes")]
        public int Duration { get; set; }
        [Display(Name = "IMDB link")]
        public string Link { get; set; }
    }
}
