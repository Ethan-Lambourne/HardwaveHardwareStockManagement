
using System.ComponentModel.DataAnnotations;

namespace HardwaveStockManagement.Models
{
    public class Memory(Guid ID, string Name, string Type, int? Stock, double? Price, string? Description, string MemoryType, int MemorySize, int MemorySpeed)
        : Items(ID, Name, Type, Stock, Price, Description)
    {
        public string MemoryType { get; set; } = MemoryType;

        public int MemorySize { get; set; } = MemorySize;

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public int MemorySpeed { get; set; } = MemorySpeed;
    }
}
