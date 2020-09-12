using System;
using System.Collections.Generic;
using System.Text;

namespace ASP.NET.Homework03.BusinessLayer.DataTransferModels
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }

    }
}
