using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Users
    {
        public Users()
        {
            Orders = new HashSet<Orders>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserType { get; set; }

        public virtual UserType UserTypeNavigation { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
