namespace HardwaveStockManagement.Repository
{
    public interface IItemsRepository<T>
    {
        T? GetItem(Guid itemID);

        List<T> GetAllItems();

        T AddItem(T item);

        bool DeleteItem(Guid itemID);

        T? EditItem(T ExampleItem, Guid itemID);
    }
}
