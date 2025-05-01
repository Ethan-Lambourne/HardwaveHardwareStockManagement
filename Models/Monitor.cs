
using System.ComponentModel.DataAnnotations;

namespace HardwaveStockManagement.Models
{
    public class Monitor(Guid ID, string Name, string Type, int? Stock, double? Price, string? Description, double ScreenSize, int RefreshRate)
        : Items(ID, Name, Type, Stock, Price, Description)
    {
        public double ScreenSize { get; set; } = ScreenSize;

        public int RefreshRate { get; set; } = RefreshRate;
    }
}
