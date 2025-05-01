using HardwaveStockManagement.Models;

namespace HardwaveStockManagement.Repository
{
    public interface IUserRepository
    {
        void SaveCurrentUserID(Guid userID);

        Guid GetCurrentUserID();

        User AddUser(User user);

        bool DeleteUser(Guid userID);

        List<User> GetAllUsers();

        User? GetUser(Guid userID);

        bool ComparePasswords(byte[] password1, string password2);
    }
}