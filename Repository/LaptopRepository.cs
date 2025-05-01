using HardwaveStockManagement.DataManagement;
using HardwaveStockManagement.Models;

namespace HardwaveStockManagement.Repository
{
    public class LaptopRepository : IItemsRepository<Laptop>
    {
        private readonly ItemContext _context = new();

        public LaptopRepository(ItemContext context) 
        {
            _context = context;
        }

        public Laptop AddItem(Laptop item)
        {
            _context.Laptops.Add(item);
            _context.SaveChanges();
            return item;
        }

        public bool DeleteItem(Guid itemID)
        {
            var item = GetItem(itemID);
            if (item != null)
            {
                _context.Laptops.Remove(item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Laptop? EditItem(Laptop ExampleItem, Guid itemID)
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
                    if (ExampleItem.RAM != 0) { item.RAM = ExampleItem.RAM; }
                    if (ExampleItem.Storage != 0) { item.Storage = ExampleItem.Storage; }
                    AddItem(item);
                }
            }
            return item;
        }

        public List<Laptop> GetAllItems()
        {
            return _context.Laptops.ToList();
        }

        public Laptop? GetItem(Guid itemID)
        {
            List<Laptop> allItems = GetAllItems();
            return allItems.FirstOrDefault(x => x.ID == itemID);
        }
    }
}
