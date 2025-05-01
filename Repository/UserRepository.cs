using System.Security.Cryptography;
using System.Text;
using HardwaveStockManagement.DataManagement;
using HardwaveStockManagement.Models;

namespace HardwaveStockManagement.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context = new();

        public UserRepository(UserContext context) 
        { 
            _context = context;
        }

        private Guid UserID = Guid.Empty;

        public void SaveCurrentUserID(Guid userId)
        {
            UserID = userId;
        }

        public Guid GetCurrentUserID()
        {
            return UserID;
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public bool DeleteUser(Guid userID)
        {
            var user = GetUser(userID);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User? GetUser(Guid userID)
        {
            List<User> allusers = GetAllUsers();
            return allusers.FirstOrDefault(x => x.ID == userID);
        }

        public bool ComparePasswords(byte[] password1, string password2)
        {
            var passwordSource = ASCIIEncoding.ASCII.GetBytes(password2);
            byte[] hashedPassword = MD5.HashData(passwordSource);
            if (password1.Length == hashedPassword.Length)
            {
                int index = 0;
                while (index < hashedPassword.Length && password1[index] == hashedPassword[index])
                {
                    index++;
                }
                if (index == hashedPassword.Length) 
                { 
                    return true;
                }
            }
            return false;
        }
    }
}
