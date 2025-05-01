using HardwaveStockManagement.Models;

namespace HardwaveStockManagement.ViewModels
{
    public class DeleteUserViewModel(List<User> Users)
    {
        public List<User> Users { get; set; } = Users;
    }
}
