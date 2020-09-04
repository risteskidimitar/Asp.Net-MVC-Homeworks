using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET.Homework02_StoreApp.Models.ViewModels
{
    public class GetMovie
    {
        [Display(Name = "Enter ID of the movie you want to buy")]
        public int IdOfMovie { get; set; }

        [Display(Name = "Enter your First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Enter your Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Your email address")]
        public string Email { get; set; }
        public long Phone { get; set; }
    }
}
