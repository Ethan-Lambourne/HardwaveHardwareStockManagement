
namespace HardwaveStockManagement.Models
{
    public class Motherboard(Guid ID, string Name, string Type, int? Stock, double? Price, string? Description, string Socket, string FormFactor)
        : Items(ID, Name, Type, Stock, Price, Description)
    {
        public string Socket { get; set; } = Socket;

        public string FormFactor { get; set; } = FormFactor;
    }
}
