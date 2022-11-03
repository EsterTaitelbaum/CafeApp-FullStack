using Entities;
using System.Threading.Tasks;

namespace DL
{
    public interface IUserDL
    {
        Task createUser(Users user);
        Task<Users> getUser(string login, string password);
        Task updateDetails(int id, Users userToUpdate);
    }
}