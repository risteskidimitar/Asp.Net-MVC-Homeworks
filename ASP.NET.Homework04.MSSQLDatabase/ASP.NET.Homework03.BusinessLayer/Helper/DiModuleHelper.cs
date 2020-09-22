using ASP.NET.Homework03.DataLayer;
using ASP.NET.Homework03.DataLayer.DbRepositories;
using ASP.NET.Homework03.DataLayer.Domain;
using ASP.NET.Homework03.DataLayer.Interfaces;
using ASP.NET.Homework03.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
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
            // CacheDb registration
            //services.AddTransient<IGenericRepository<Movie>, MovieRepository>();
            //services.AddTransient<IGenericRepository<OrderDetails>, OrderRepository>();
            //services.AddTransient<IGenericRepository<User>, UserRepository>();

            // Sql server repo registration
            services.AddTransient<IGenericRepository<Movie>, DbMovieRepository>();
            services.AddTransient<IGenericRepository<OrderDetails>, DbOrderRepository>();
            services.AddTransient<IGenericRepository<User>, DbUserRepository>();
            return services;
        }
        public static IServiceCollection RegisterDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MovieAppContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
