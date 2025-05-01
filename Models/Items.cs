using System.ComponentModel.DataAnnotations;

namespace HardwaveStockManagement.Models
{
    public abstract class Items(Guid ID, string Name, string Type, int? Stock, double? Price, string? Description)
    {
        [Key]
        public int PK { get; set; }

        public Guid ID { get; set; } = ID;

        public string Name { get; set; } = Name;

        public string Type { get; set; } = Type;

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public int? Stock { get; set; } = Stock;

        [DisplayFormat(DataFormatString = "{0:#,##0.##}")]
        public double? Price { get; set; } = Price;

        public string? Description { get; set; } = Description;

        public int OrderAmount { get; set; } = 0;
    }
}
