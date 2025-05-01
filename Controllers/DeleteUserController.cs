using HardwaveStockManagement.Repository;
using HardwaveStockManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HardwaveStockManagement.Controllers
{
    public class DeleteUserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("/DeleteUser")]
        public IActionResult DeleteUserView()
        {
            DeleteUserViewModel deleteUserViewModel = new(_userRepository.GetAllUsers());
            return View(deleteUserViewModel);
        }

        public IActionResult DeleteUser(Guid UserID) 
        { 
            var isUserDeleted = _userRepository.DeleteUser(UserID);
            if (isUserDeleted)
            {
                return RedirectToAction("Index", "Home", new { userRecentlyDeleted = true });
            }
            else 
            { 
                return BadRequest();
            }
        }
    }
}
