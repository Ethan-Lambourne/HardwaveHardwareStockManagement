
namespace HardwaveStockManagement.DataManagement
{
    public class DbInitializer
    {
        public static void Initialize(ItemContext itemContext, UserContext userContext, OrderContext orderContext) 
        {
            itemContext.Database.EnsureCreated();
            userContext.Database.EnsureCreated();
            orderContext.Database.EnsureCreated();
        }
    }
}
