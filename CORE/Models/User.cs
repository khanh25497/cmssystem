using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Models
{
    public class User
    {
        public int Id { get; set; } //ID primary key
        public int RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int SchoolId { get; set; }

        public virtual Role Role { get; set; }
        public virtual School School { get; set; }
    }
}
