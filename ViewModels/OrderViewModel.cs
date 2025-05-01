using HardwaveStockManagement.Models;

namespace HardwaveStockManagement.ViewModels
{
    public class OrderViewModel(Dictionary<Guid, int> OrderContent, List<Case> CaseList, List<CPU> CPUList, List<GraphicsCard> GraphicsCardList, List<Laptop> LaptopList,
        List<Memory> MemoryList, List<Models.Monitor> MonitorList, List<Motherboard> MotherboardList, List<Storage> StorageList)
    {
        public Dictionary<Guid, int> OrderContent { get; set; } = OrderContent;

        public List<Case> CaseList { get; set; } = CaseList;

        public List<CPU> CPUList { get; set; } = CPUList;

        public List<GraphicsCard> GraphicsCardList { get; set; } = GraphicsCardList;

        public List<Laptop> LaptopList { get; set; } = LaptopList;

        public List<Memory> MemoryList { get; set; } = MemoryList;

        public List<Models.Monitor> MonitorList { get; set; } = MonitorList;

        public List<Motherboard> MotherboardList { get; set; } = MotherboardList;

        public List<Storage> StorageList { get; set; } = StorageList;

        public Items? GetItemFromID(Guid itemId)
        {
            foreach (var item in CaseList)
            {
                if (item.ID == itemId)
                {
                    return item;
                }
            }
            foreach (var item in CPUList)
            {
                if (item.ID == itemId)
                {
                    return item;
                }
            }
            foreach (var item in GraphicsCardList)
            {
                if (item.ID == itemId)
                {
                    return item;
                }
            }
            foreach (var item in LaptopList)
            {
                if (item.ID == itemId)
                {
                    return item;
                }
            }
            foreach (var item in MemoryList)
            {
                if (item.ID == itemId)
                {
                    return item;
                }
            }
            foreach (var item in MonitorList)
            {
                if (item.ID == itemId)
                {
                    return item;
                }
            }
            foreach (var item in MotherboardList)
            {
                if (item.ID == itemId)
                {
                    return item;
                }
            }
            foreach (var item in StorageList)
            {
                if (item.ID == itemId)
                {
                    return item;
                }
            }
            return null;
        }
    }

}
