using ASP.NET.Homework03.BusinessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASP.NET.Homework03.BusinessLayer.Helper
{
    public class ResultsWrapperHelper
    {
        public MovieDetailsVM MovieDetailsVM { get; set; }
        public OrderDetailsVM OrderDetailsVM { get; set; }
        public UploadMovieVM UploadMovieVM { get; set; }

        public string Message { get; set; }

    }
}
