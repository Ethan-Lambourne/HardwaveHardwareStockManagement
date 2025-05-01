namespace HardwaveStockManagement.GenerateID
{
    public class GenerateItemID : IGenerateItemID
    {
        public Guid GenerateID()
        {
            return Guid.NewGuid();
        }
    }
}
