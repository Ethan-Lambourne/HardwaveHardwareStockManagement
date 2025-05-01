using HardwaveStockManagement.DataManagement;
using HardwaveStockManagement.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace HardwaveStockManagement.Repository
{
    public class MonitorRepository : IItemsRepository<Models.Monitor>
    {
        private readonly ItemContext _context = new();

        public MonitorRepository(ItemContext context)
        {
            _context = context;
        }

        public Models.Monitor AddItem(Models.Monitor item)
        {
            _context.Monitors.Add(item);
            _context.SaveChanges();
            return item;
        }

        public bool DeleteItem(Guid itemID)
        {
            var item = GetItem(itemID);
            if (item != null)
            {
                _context.Monitors.Remove(item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Models.Monitor? EditItem(Models.Monitor ExampleItem, Guid itemID)
        {
            var item = GetItem(itemID);
            if (item != null)
            {
                var isDeleted = DeleteItem(itemID);
                if (isDeleted)
                {
                    if (item.PK != 0) { item.PK = 0; }
                    if (ExampleItem.Name != "") { item.Name = ExampleItem.Name; }
                    if (ExampleItem.Stock != null) { item.Stock = ExampleItem.Stock; }
                    if (ExampleItem.Price != null) { item.Price = (double)ExampleItem.Price; }
                    if (ExampleItem.Description != "") { item.Description = ExampleItem.Description; }
                    if (ExampleItem.ScreenSize != 0) { item.ScreenSize = ExampleItem.ScreenSize; }
                    if (ExampleItem.RefreshRate != 0) { item.RefreshRate = ExampleItem.RefreshRate; }
                    AddItem(item);
                }
            }
            return item;
        }

        public List<Models.Monitor> GetAllItems()
        {
            return _context.Monitors.ToList();
        }

        public Models.Monitor? GetItem(Guid itemID)
        {
            List<Models.Monitor> allItems = GetAllItems();
            return allItems.FirstOrDefault(x => x.ID == itemID);
        }
    }
}
