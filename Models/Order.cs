using System.ComponentModel.DataAnnotations;

namespace HardwaveStockManagement.Models
{
    public class Order(Guid OrderID, Guid UserID, Guid[] OrderItems, int[] OrderAmounts)
    {
        [Key]
        public int PK { get; set; }

        public Guid OrderID { get; set; } = OrderID;

        public Guid UserID { get; set; } = UserID;

        public Guid[] OrderItems { get; set; } = OrderItems;

        public int[] OrderAmounts { get; set; } = OrderAmounts;
    }
}