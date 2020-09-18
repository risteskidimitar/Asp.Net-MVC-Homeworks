using ASP.NET.Homework03.DataLayer.Domain;
using ASP.NET.Homework03.DataLayer.Interfaces;
using ASP.NET.Homework03.DataLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASP.NET.Homework03.BusinessLayer.Helper
{
    public static class DiModuleHelper
    {
        public static IServiceCollection RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IGenericRepository<Movie>, MovieRepository>();
            services.AddTransient<IGenericRepository<OrderMovieStatsHistory>, OrderRepository>();
            services.AddTransient<IGenericRepository<User>, UserRepository>();
            return services;
        }
    }
}
