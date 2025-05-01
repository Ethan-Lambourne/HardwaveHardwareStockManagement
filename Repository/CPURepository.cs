using HardwaveStockManagement.DataManagement;
using HardwaveStockManagement.Models;

namespace HardwaveStockManagement.Repository
{
    public class CPURepository : IItemsRepository<CPU>
    {
        private readonly ItemContext _context = new();

        public CPURepository(ItemContext context)
        {
            _context = context;
        }

        public CPU AddItem(CPU item)
        {
            _context.CPUs.Add(item);
            _context.SaveChanges();
            return item;
        }

        public bool DeleteItem(Guid itemID)
        {
            var item = GetItem(itemID);
            if (item != null)
            {
                _context.CPUs.Remove(item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public CPU? EditItem(CPU ExampleItem, Guid itemID)
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
                    if (ExampleItem.Cores != 0) { item.Cores = ExampleItem.Cores; }
                    if (ExampleItem.ClockSpeed != 0) { item.ClockSpeed = ExampleItem.ClockSpeed; }
                    if (ExampleItem.Socket != null) { item.Socket = ExampleItem.Socket; }
                    AddItem(item);
                }
            }
            return item;
        }

        public List<CPU> GetAllItems()
        {
            return _context.CPUs.ToList();
        }

        public CPU? GetItem(Guid itemID)
        {
            List<CPU> allItems = GetAllItems();
            return allItems.FirstOrDefault(x => x.ID == itemID);
        }
    }
}
