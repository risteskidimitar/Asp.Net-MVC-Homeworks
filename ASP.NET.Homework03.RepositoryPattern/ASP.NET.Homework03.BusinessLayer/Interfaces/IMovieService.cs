using ASP.NET.Homework03.BusinessLayer.Helper;
using ASP.NET.Homework03.BusinessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASP.NET.Homework03.BusinessLayer.Interfaces
{
    public interface IMovieService
    {
        List<MovieDetailsVM> GetAllMovies();
        HelperClass MovieById(OrderDetailsVM orderDetails);
        HelperClass UploadMovie(UploadMovieVM uploadMovieVM);
    }
}
