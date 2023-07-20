using MVC_Aptech.Models;
using MVC_Aptech.Repositories;
using MVC_Aptech.Models.DTOs;

namespace MVC_Aptech.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public bool ValidateUserCredentials(UserLoginRequest userLoginRequest)
        {
            // Implement logic to validate user credentials (e.g., check if email and password match)
            // You can use the UserRepository to retrieve the user by email and then compare passwords

            User user = _userRepository.GetByEmail(userLoginRequest.Email!);
            if (user != null)
            {
                return user.Password == userLoginRequest.Password;
            }

            return false;
        }

    }
}
