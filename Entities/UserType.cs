using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class UserType
    {
        public UserType()
        {
            Users = new HashSet<Users>();
        }

        public string UserType1 { get; set; }
        public int UserTypeId { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
