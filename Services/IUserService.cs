using System.Collections.Generic;
using MVC_Aptech.Models;
using MVC_Aptech.Models.DTOs;

namespace MVC_Aptech.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(User user);
        bool ValidateUserCredentials(UserLoginRequest userLoginRequest);
    }

}
