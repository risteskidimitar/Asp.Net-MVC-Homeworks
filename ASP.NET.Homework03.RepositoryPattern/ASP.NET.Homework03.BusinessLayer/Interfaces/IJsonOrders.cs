using ASP.NET.Homework03.BusinessLayer.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASP.NET.Homework03.BusinessLayer.Interfaces
{
    public interface IJsonOrders
    {
        List<OrderMovieStatsDto> JsonOrders();
    }
}
