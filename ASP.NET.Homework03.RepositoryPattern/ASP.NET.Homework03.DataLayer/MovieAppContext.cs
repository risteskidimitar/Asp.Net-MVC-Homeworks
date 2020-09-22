using ASP.NET.Homework03.DataLayer.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASP.NET.Homework03.DataLayer
{
    public class MovieAppContext : DbContext
    {
        public MovieAppContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OrderMovieStatsHistory> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
