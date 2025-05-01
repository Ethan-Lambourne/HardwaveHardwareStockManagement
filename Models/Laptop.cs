using System.ComponentModel.DataAnnotations;

namespace HardwaveStockManagement.Models
{
    public class Laptop(Guid ID, string Name, string Type, int? Stock, double? Price, string? Description, double ScreenSize, int RAM, int Storage)
        : Items(ID, Name, Type, Stock, Price, Description)
    {
        public double ScreenSize { get; set; } = ScreenSize;

        public int RAM { get; set; } = RAM;

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public int Storage { get; set; } = Storage;
    }
}
