using Entities;
using System.Threading.Tasks;

namespace BL
{
    public interface IUserBL
    {
        Task createUser(Users user);
        Task<Users> getUser(string email, string password);
        Task updateDetails(int id, Users userToUpdate);
    }
}