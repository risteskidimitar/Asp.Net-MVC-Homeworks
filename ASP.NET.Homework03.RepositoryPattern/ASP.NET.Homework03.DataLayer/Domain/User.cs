using System;
using System.Collections.Generic;
using System.Text;

namespace ASP.NET.Homework03.DataLayer.Domain
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }

        public bool IsAdmin = false;
    }
}
