
namespace HardwaveStockManagement.DataManagement
{
    public class DbInitializer
    {
        public static void Initialize(ItemContext itemContext, UserContext userContext, OrderContext orderContext) 
        {
            itemContext.Database.EnsureCreated();
            var wasUserDatabaseCreated = userContext.Database.EnsureCreated();
            orderContext.Database.EnsureCreated();
        
            if (wasUserDatabaseCreated) 
            {
                UserRepository _userRepository = new(userContext);
                User initialAdminUser = new(Guid.NewGuid(), "Admin1", MD5.HashData(ASCIIEncoding.ASCII.GetBytes("admin")), true);
                _userRepository.AddUser(initialAdminUser);
            }
        }
    }
}
