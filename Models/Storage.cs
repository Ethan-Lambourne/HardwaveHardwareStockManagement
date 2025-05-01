
using System.ComponentModel.DataAnnotations;

namespace HardwaveStockManagement.Models
{
    public class Storage(Guid ID, string Name, string Type, int? Stock, double? Price, string? Description, string StorageType, int StorageSize)
        : Items(ID, Name, Type, Stock, Price, Description)
    {
        public string StorageType { get; set; } = StorageType;

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public int StorageSize { get; set; } = StorageSize;
    }
}
