using HardwaveStockManagement.DataManagement;
using HardwaveStockManagement.Models;

namespace HardwaveStockManagement.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context = new();

        public OrderRepository(OrderContext context)
        {
            _context = context;
        }

        private Dictionary<Guid, int> OrderContent = new();

        public bool AddItemToOrder(Guid itemId, int amount)
        {
            OrderContent.Add(itemId, amount);
            return true;
        }

        public bool DeleteItemFromOrder(Guid itemId)
        {
            if (OrderContent.ContainsKey(itemId)) 
            {
                OrderContent.Remove(itemId);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Dictionary<Guid, int> GetOrderContent()
        {
            return OrderContent;
        }

        public bool SubmitOrder(Guid userId)
        {
            if (OrderContent != null && OrderContent.Count > 0)
            {
                Guid[] guidArray = new Guid[OrderContent.Count];
                int[] intArray = new int[OrderContent.Count];
                int index = 0;
                foreach (KeyValuePair<Guid, int> entry in OrderContent)
                {
                    guidArray[index] = entry.Key;
                    intArray[index] = entry.Value;
                    index++;
                }
                Order newOrder = new(Guid.NewGuid(), userId, guidArray, intArray);
                _context.Orders.Add(newOrder);
                _context.SaveChanges();
                OrderContent.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public bool DeleteOrder(Guid orderId)
        {
            Order? order = GetOrder(orderId);
            if (order != null) 
            { 
                _context.Orders.Remove(order);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Order? GetOrder(Guid orderId)
        {
            List<Order> allOrders = GetAllOrders();
            return allOrders.FirstOrDefault(x => x.OrderID == orderId);
        }
    }
}
