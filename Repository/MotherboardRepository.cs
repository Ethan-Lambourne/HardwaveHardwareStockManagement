using HardwaveStockManagement.DataManagement;
using HardwaveStockManagement.Models;

namespace HardwaveStockManagement.Repository
{
    public class MotherboardRepository : IItemsRepository<Motherboard>
    {
        private readonly ItemContext _context = new();

        public MotherboardRepository(ItemContext context)
        {
            _context = context;
        }

        public Motherboard AddItem(Motherboard item)
        {
            _context.Motherboards.Add(item);
            _context.SaveChanges();
            return item;
        }

        public bool DeleteItem(Guid itemID)
        {
            var item = GetItem(itemID);
            if (item != null)
            {
                _context.Motherboards.Remove(item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Motherboard? EditItem(Motherboard ExampleItem, Guid itemID)
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
                    if (ExampleItem.Socket != "") { item.Socket = ExampleItem.Socket; }
                    if (ExampleItem.FormFactor != "") { item.FormFactor = ExampleItem.FormFactor; }
                    AddItem(item);
                }
            }
            return item;
        }

        public List<Motherboard> GetAllItems()
        {
            return _context.Motherboards.ToList();
        }

        public Motherboard? GetItem(Guid itemID)
        {
            List<Motherboard> allItems = GetAllItems();
            return allItems.FirstOrDefault(x => x.ID == itemID);
        }
    }
}
