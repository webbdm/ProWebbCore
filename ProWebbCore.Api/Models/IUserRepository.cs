using System.Collections.Generic;
using ProWebbCore.Shared;

namespace ProWebbCore.Api.Models
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        User AddUser(User user);
        User UpdateUser(User user);
        void DeleteUser(int id);
    }
}
