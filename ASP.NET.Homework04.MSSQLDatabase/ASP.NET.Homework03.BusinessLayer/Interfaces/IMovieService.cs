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
        ResultsWrapperHelper MovieById(OrderDetailsVM orderDetails);
        ResultsWrapperHelper UploadMovie(UploadMovieVM uploadMovieVM);
    }
}
