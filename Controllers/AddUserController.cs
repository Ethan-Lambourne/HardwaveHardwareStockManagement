using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using HardwaveStockManagement.GenerateID;
using HardwaveStockManagement.Models;
using HardwaveStockManagement.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HardwaveStockManagement.Controllers
{
    public class AddUserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IGenerateItemID _generateItemID;

        public AddUserController(IUserRepository userRepository, IGenerateItemID generateItemID)
        {
            _userRepository = userRepository;
            _generateItemID = generateItemID;
        }

        [Route("/AddUserForm")]
        public IActionResult AddUserView()
        {
            return View();
        }

        public IActionResult AddUser(string Username, string Password, bool Admin)
        {
            Guid ID = _generateItemID.GenerateID();
            var passwordSource = ASCIIEncoding.ASCII.GetBytes(Password);
            byte[] hashedPassword = MD5.HashData(passwordSource);
            User user = new(ID, Username, hashedPassword, Admin);
            var addedUser = _userRepository.AddUser(user);
            if (user.ID == addedUser.ID)
            {
                return RedirectToAction("Index", "Home", new { userRecentlyCreated = true });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
