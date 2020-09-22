using ASP.NET.Homework03.DataLayer.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ASP.NET.Homework03.DataLayer.Domain
{
    public class User 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public TypeOfUser TypeOfUser { get; set; } = TypeOfUser.StandardUser;
        public List<OrderDetails> Orders { get; set; }
    }
}
