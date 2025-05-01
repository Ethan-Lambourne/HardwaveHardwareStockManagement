using HardwaveStockManagement.DataManagement;
using HardwaveStockManagement.Models;

namespace HardwaveStockManagement.Repository
{
    public class CaseRepository : IItemsRepository<Case>
    {
        private readonly ItemContext _context = new();

        public CaseRepository(ItemContext context)
        {
            _context = context;
        }

        public Case AddItem(Case item)
        {
            _context.Cases.Add(item);
            _context.SaveChanges();
            return item;
        }

        public bool DeleteItem(Guid itemID)
        {
            var item = GetItem(itemID);
            if (item != null)
            {
                _context.Cases.Remove(item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Case? EditItem(Case ExampleItem, Guid itemID)
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
                    if (ExampleItem.FormFactor != null) { item.FormFactor = ExampleItem.FormFactor; }
                    AddItem(item);
                }
            }
            return item;
        }

        public List<Case> GetAllItems()
        {
            return _context.Cases.ToList();
        }

        public Case? GetItem(Guid itemID)
        {
            List<Case> allItems = GetAllItems();
            return allItems.FirstOrDefault(x => x.ID == itemID);
        }
    }
}
