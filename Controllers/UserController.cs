using Microsoft.AspNetCore.Mvc;
using MVC_Aptech.Models;
using MVC_Aptech.Models.DTOs;
using MVC_Aptech.Repositories;
using MVC_Aptech.Services;
using System.Security.Cryptography;
using System.Text;

namespace MVC_Aptech.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            UserRegisterRequest userRegisterRequest = new UserRegisterRequest();
            return View(userRegisterRequest);//Views/User/Register.cshtml
        }

        [HttpPost]
        public IActionResult Register(UserRegisterRequest userRegisterRequest)
        {
            if (ModelState.IsValid)
            {
                // Create a new User object from the UserRegisterRequest data
                User user = new User
                {
                    Email = userRegisterRequest.Email,
                    FullName = userRegisterRequest.FullName,
                    Password = userRegisterRequest.Password
                    // You might set other properties here if needed
                };

                // Save the user to the database using the IUserService
                _userService.AddUser(user);
                return RedirectToAction("Login");
            }

            return View(userRegisterRequest);
        }


        [HttpGet]
        public IActionResult Login()
        {
            UserLoginRequest userLoginRequest = new UserLoginRequest();
            return View(userLoginRequest);//Views/User/Register.cshtml
        }

        [HttpPost]
        public IActionResult Login(UserLoginRequest userLoginRequest)
        {
            if (ModelState.IsValid)
            {
                // Xác thực người dùng sử dụng IUserService
                bool isAuthenticated = _userService.ValidateUserCredentials(userLoginRequest);

                if (isAuthenticated)
                {
                    // Xác thực thành công, chuyển hướng đến trang "Success"
                    return RedirectToAction("Success");
                }
                else
                {
                    // Xác thực không thành công, hiển thị thông báo lỗi
                    ModelState.AddModelError("", "Invalid email or password. Please try again.");
                }
            }

            // Trả về view Login với model userLoginRequest (bao gồm thông tin người dùng đã nhập)
            return View(userLoginRequest);
        }
        public IActionResult Success()
        {
            List<User> userList = (List<User>)_userService.GetAllUsers();

            var userViewModelList = userList.Select(user => new UserViewModel
            {
                Email = user.Email,
                FullName = user.FullName,
                EncryptedPassword = EncryptMD5(user.Password!)
            }).ToList();

            return View(userViewModelList);
        }
        // Phương thức mã hóa MD5
        public string EncryptMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
