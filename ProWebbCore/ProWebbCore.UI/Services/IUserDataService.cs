using ProWebbCore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProWebbCore.UI.Services
{
    public interface IUserDataService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserDetails(int userId);
        Task<User> AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int userId); 
    }
}
