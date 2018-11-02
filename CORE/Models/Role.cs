using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Models
{
    public class Role
    {
        public int Id { get; set; } //Role ID primary key
        public string Name { get; set; }
        
        public virtual ICollection<User> Users { get; set; }
    }
}
