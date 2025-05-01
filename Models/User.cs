using System.ComponentModel.DataAnnotations;

namespace HardwaveStockManagement.Models
{
    public class User(Guid ID, string Username, byte[] Password, bool Admin)
    {
        [Key]
        public int PK { get; set; }

        public Guid ID { get; set; } = ID;

        public string Username { get; set; } = Username;

        public byte[] Password { get; set; } = Password;

        public bool Admin { get; set; } = Admin;
    }
}
