using HardwaveStockManagement.DataManagement;
using HardwaveStockManagement.Models;

namespace HardwaveStockManagement.Repository
{
    public class MemoryRepository : IItemsRepository<Memory>
    {
        private readonly ItemContext _context = new();

        public MemoryRepository(ItemContext context)
        {
            _context = context;
        }

        public Memory AddItem(Memory item)
        {
            _context.MemorySticks.Add(item);
            _context.SaveChanges();
            return item;
        }

        public bool DeleteItem(Guid itemID)
        {
            var item = GetItem(itemID);
            if (item != null)
            {
                _context.MemorySticks.Remove(item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Memory? EditItem(Memory ExampleItem, Guid itemID)
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
                    if (ExampleItem.MemoryType != null) { item.MemoryType = ExampleItem.MemoryType; }
                    if (ExampleItem.MemorySize != 0) { item.MemorySize = ExampleItem.MemorySize; }
                    if (ExampleItem.MemorySpeed != 0) { item.MemorySpeed = ExampleItem.MemorySpeed; }
                    AddItem(item);
                }
            }
            return item;
        }

        public List<Memory> GetAllItems()
        {
            return _context.MemorySticks.ToList();
        }

        public Memory? GetItem(Guid itemID)
        {
            List<Memory> allItems = GetAllItems();
            return allItems.FirstOrDefault(x => x.ID == itemID);
        }
    }
}
