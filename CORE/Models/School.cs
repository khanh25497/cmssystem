using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Models
{
    public class School
    {
        public int Id { get; set; }// School Id primary key
        public string Name { get; set; }// School Name

        public virtual ICollection<User> Users { get; set; }
    }
}
