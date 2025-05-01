
namespace HardwaveStockManagement.Models
{
    public class Case(Guid ID, string Name, string Type, int? Stock, double? Price, string? Description, string FormFactor)
        : Items(ID, Name, Type, Stock, Price, Description)
    {
        public string FormFactor { get; set; } = FormFactor;
    }
}
