using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserBL : IUserBL
    {
        IUserDL userDL;

        public UserBL(IUserDL userDl)
        {
            this.userDL = userDl;
        }

        public Task<Users> getUser(string email, string password)
        {
            return userDL.getUser(email, password);
        }

        public async Task createUser(Users user)
        {
            await userDL.createUser(user);
        }

        public async Task updateDetails(int id, Users userToUpdate)
        {
            await userDL.updateDetails(id, userToUpdate);
        }
    }
}
