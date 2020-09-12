using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ASP.NET.Homework03.BusinessLayer.ViewModels
{
    public class OrderDetailsVM
    {
        [Required]
        [Display(Name = "Enter ID of the movie you want to buy")]
        public int IdOfMovie { get; set; }
        [Required]
        [Display(Name = "Enter your First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Enter your Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Your email address")]
        public string Email { get; set; }
        [Required]
        public long Phone { get; set; }
    }
}
