using HardwaveStockManagement.Models;

namespace HardwaveStockManagement.Repository
{
    public interface IOrderRepository
    {
        bool AddItemToOrder(Guid item, int amount);

        bool DeleteItemFromOrder(Guid item);

        Dictionary<Guid, int> GetOrderContent();

        bool SubmitOrder(Guid userId);

        List<Order> GetAllOrders();

        bool DeleteOrder(Guid orderId);

        Order? GetOrder(Guid orderId);
    }
}
