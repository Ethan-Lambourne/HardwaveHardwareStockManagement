using HardwaveStockManagement.Models;

namespace HardwaveStockManagement.ViewModels
{
    public class AdminOrdersViewModel(List<Order> Orders)
    {
        public List<Order> Orders { get; set; } = Orders;
    }
}
