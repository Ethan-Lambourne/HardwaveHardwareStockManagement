using System.ComponentModel.DataAnnotations;

namespace HardwaveStockManagement.ViewModels
{
    public class AddItemViewModel
    {
        public Guid? ID { get; set; }

        public string? Name { get; set; }

        public string? Type { get; set; }

        public int? Stock { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0.##}")]
        public double? Price { get; set; }

        public string? Description { get; set; }

        public double? ScreenSize { get; set; }

        public int? RAM { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public int? Storage { get; set; }

        public int? VRAM { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public int? CudaCores { get; set; }

        public string? FormFactor { get; set; }

        public int? Cores { get; set; }

        public double? ClockSpeed { get; set; }

        public string? Socket { get; set; }

        public string? MemoryType { get; set; }

        public int? MemorySize { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public int? MemorySpeed { get; set; }

        public int? RefreshRate { get; set; }

        public string? StorageType { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public int? StorageSize { get; set; }
    }
}
