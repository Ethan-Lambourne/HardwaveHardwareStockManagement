using HardwaveStockManagement.Models;

namespace HardwaveStockManagement.ViewModels
{
    public class DeleteItemViewModel(Case? PcCase, CPU? cpu, GraphicsCard? graphicsCard, Laptop? laptop,
        Memory? memory, Models.Monitor? monitor, Motherboard? motherboard, Storage? storage)
    {
        public Case? Case { get; set; } = PcCase;

        public CPU? Cpu { get; set; } = cpu;

        public GraphicsCard? GraphicsCard { get; set; } = graphicsCard;

        public Laptop? Laptop { get; set; } = laptop;

        public Memory? Memory { get; set; } = memory;

        public Models.Monitor? Monitor { get; set; } = monitor;

        public Motherboard? Motherboard { get; set; } = motherboard;

        public Storage? Storage { get; set; } = storage;
    }
}
