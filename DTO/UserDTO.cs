using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int UserType { get; set; }
    }
}
