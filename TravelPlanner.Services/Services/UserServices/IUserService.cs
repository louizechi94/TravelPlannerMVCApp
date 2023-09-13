using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Models.ViewModeles.UserModels;

namespace TravelPlanner.Services.Services.UserServices
{
    public interface IUserService
    {
        Task<bool> AddUser(UserCreate user);
        Task<bool>  UpdateUser(UserEdit user);
        Task<bool> DeleteUser(int userId);
        Task<UserDetail> GetUser(int userId);
        Task<IEnumerable<UserListItem>> GetUsers();

    }
}
