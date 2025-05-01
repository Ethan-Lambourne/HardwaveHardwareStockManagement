using System.ComponentModel.DataAnnotations;

namespace HardwaveStockManagement.Models
{
    public class GraphicsCard(Guid ID, string Name, string Type, int? Stock, double? Price, string? Description, int VRAM, int CudaCores)
        : Items(ID, Name, Type, Stock, Price, Description)
    {
        public int VRAM { get; set; } = VRAM;

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public int CudaCores { get; set; } = CudaCores;
    }
}
