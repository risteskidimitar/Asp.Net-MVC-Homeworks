using ASP.NET.Homework03.BusinessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASP.NET.Homework03.BusinessLayer.Interfaces
{
    public interface IMovieService
    {
        List<MovieDetailsVM> GetAllMovies();
        bool MovieById(OrderDetailsVM orderDetails);
        string UploadMovie(UploadMovieVM uploadMovieVM);
    }
}
