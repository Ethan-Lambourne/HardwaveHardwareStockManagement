using HardwaveStockManagement.Models;

namespace HardwaveStockManagement.ViewModels
{
    public class StoreViewModel(List<Case> CaseList, List<CPU> CPUList, List<GraphicsCard> GraphicsCardList, List<Laptop> LaptopList,
        List<Memory> MemoryList, List<Models.Monitor> MonitorList, List<Motherboard> MotherboardList, List<Storage> StorageList,
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

        public string? SearchInput { get; set; } = SearchInput;

        public List<Items>? SearchOutput { get; set; } = SearchOutput;
    }
}
