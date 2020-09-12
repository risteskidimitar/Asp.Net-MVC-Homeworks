using ASP.NET.Homework03.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASP.NET.Homework03.DataLayer.Domain
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
    }
}
