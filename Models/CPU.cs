namespace HardwaveStockManagement.Models
{
    public class CPU(Guid ID, string Name, string Type, int? Stock, double? Price, string? Description, int Cores, double ClockSpeed, string Socket)
        : Items(ID, Name, Type, Stock, Price, Description)
    {
        public int Cores { get; set; } = Cores;

        public double ClockSpeed { get; set; } = ClockSpeed;

        public string Socket { get; set; } = Socket;
    }
}
