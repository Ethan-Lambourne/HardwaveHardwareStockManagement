using HardwaveStockManagement.DataManagement;
using HardwaveStockManagement.Models;

namespace HardwaveStockManagement.Repository
{
    public class GraphicsCardRepository : IItemsRepository<GraphicsCard>
    {
        private readonly ItemContext _context = new();

        public GraphicsCardRepository(ItemContext context)
        {
            _context = context;
        }

        public GraphicsCard AddItem(GraphicsCard item)
        {
            _context.GraphicsCards.Add(item);
            _context.SaveChanges();
            return item;
        }

        public bool DeleteItem(Guid itemID)
        {
            var item = GetItem(itemID);
            if (item != null)
            {
                _context.GraphicsCards.Remove(item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public GraphicsCard? EditItem(GraphicsCard ExampleItem, Guid itemID)
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
                    if (ExampleItem.CudaCores != 0) { item.CudaCores = ExampleItem.CudaCores; }
                    if (ExampleItem.VRAM != 0) { item.VRAM = ExampleItem.VRAM; }
                    AddItem(item);
                }
            }
            return item;
        }

        public List<GraphicsCard> GetAllItems()
        {
            return _context.GraphicsCards.ToList();
        }

        public GraphicsCard? GetItem(Guid itemID)
        {
            List<GraphicsCard> allItems = GetAllItems();
            return allItems.FirstOrDefault(x => x.ID == itemID);
        }
    }
}
