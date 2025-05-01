using HardwaveStockManagement.DataManagement;
using HardwaveStockManagement.Models;

namespace HardwaveStockManagement.Repository
{
    public class StorageRepository : IItemsRepository<Storage>
    {
        private readonly ItemContext _context = new();

        public StorageRepository(ItemContext context)
        {
            _context = context;
        }

        public Storage AddItem(Storage item)
        {
            _context.Storages.Add(item);
            _context.SaveChanges();
            return item;
        }

        public bool DeleteItem(Guid itemID)
        {
            var item = GetItem(itemID);
            if (item != null)
            {
                _context.Storages.Remove(item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Storage? EditItem(Storage ExampleItem, Guid itemID)
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
                    if (ExampleItem.StorageType != "") { item.StorageType = ExampleItem.StorageType; }
                    if (ExampleItem.StorageSize != 0) { item.StorageSize = ExampleItem.StorageSize; }
                    AddItem(item);
                }
            }
            return item;
        }

        public List<Storage> GetAllItems()
        {
            return _context.Storages.ToList();
        }

        public Storage? GetItem(Guid itemID)
        {
            List<Storage> allItems = GetAllItems();
            return allItems.FirstOrDefault(x => x.ID == itemID);
        }
    }
}
