using HardwaveStockManagement.Repository;
using HardwaveStockManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HardwaveStockManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult LogInView(bool FailedLogin)
        {
            LogInViewModel logInViewModel = new( null, null, FailedLogin);
            return View(logInViewModel);
        }

        public IActionResult LogIn(string username, string password)
        {
            foreach (var user in _userRepository.GetAllUsers())
            {
                if (user.Username == username && _userRepository.ComparePasswords(user.Password, password)) 
                {
                    _userRepository.SaveCurrentUserID(user.ID);
                    if (user.Admin)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("StoreView", "Store");
                    }
                }
            }
            LogInViewModel logInViewModel = new(null, null, true);
            return View("LogInView", logInViewModel);
        }
    }
}
