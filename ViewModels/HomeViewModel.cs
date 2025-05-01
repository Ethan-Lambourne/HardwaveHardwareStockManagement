using HardwaveStockManagement.Models;

namespace HardwaveStockManagement.ViewModels
{
    public class HomeViewModel(List<Case> CaseList, List<CPU> CPUList, List<GraphicsCard> GraphicsCardList, List<Laptop> LaptopList,
        List<Memory> MemoryList, List<Models.Monitor> MonitorList, List<Motherboard> MotherboardList, List<Storage> StorageList,
        bool itemRecentlyAdded, bool itemRecentlyEdited, bool itemRecentlyDeleted, bool userRecentlyCreated, bool userRecentlyDeleted, 
        string? SearchInput, List<Items>? SearchOutput)
    {
        public List<Case> CaseList { get; set; } = CaseList;

        public List<CPU> CPUList { get; set; } = CPUList;

        public List<GraphicsCard> GraphicsCardList { get; set; } = GraphicsCardList;

        public List<Laptop> LaptopList { get; set; } = LaptopList;

        public List<Memory> MemoryList { get; set; } = MemoryList;

        public List<Models.Monitor> MonitorList { get; set; } = MonitorList;

        public List<Motherboard> MotherboardList { get; set; } = MotherboardList;

        public List<Storage> StorageList { get; set; } = StorageList;

        public bool itemRecentlyAdded { get; set; } = itemRecentlyAdded;

        public bool itemRecentlyEdited { get; set; } = itemRecentlyEdited;

        public bool itemRecentlyDeleted { get; set; } = itemRecentlyDeleted;

        public bool userRecentlyCreated { get; set; } = userRecentlyCreated;

        public bool userRecentlyDeleted { get; set; } = userRecentlyDeleted;

        public string? SearchInput { get; set; } = SearchInput;

        public List<Items>? SearchOutput { get; set; } = SearchOutput;
    }
}
