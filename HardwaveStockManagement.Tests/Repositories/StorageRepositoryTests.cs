using HardwaveStockManagement.DataManagement;
using HardwaveStockManagement.Models;
using HardwaveStockManagement.Repository;

namespace HardwaveStockManagement.Tests.Repositories
{
    public class StorageRepositoryTests
    {
        private readonly StorageRepository _storageRepository;

        public StorageRepositoryTests()
        {
            ItemContext context = new();
            _storageRepository = new(context);
        }

        private Storage item;

        [SetUp]
        public void Setup()
        {
            item = new(Guid.NewGuid(), "test storage", "storage", 11, 22.22, "test storage description", "test storage type", 33);
        }

        [Test]
        public void GetIndividualStorageUsingStorageRepository()
        {
            _storageRepository.AddItem(item);

            var check = _storageRepository.GetItem(item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Name, Is.EqualTo(item.Name));
                Assert.That(check.Stock, Is.EqualTo(item.Stock));
                Assert.That(check.Price, Is.EqualTo(item.Price));
                Assert.That(check.Description, Is.EqualTo(item.Description));
                Assert.That(check.StorageType, Is.EqualTo(item.StorageType));
                Assert.That(check.StorageSize, Is.EqualTo(item.StorageSize));
            });
            _storageRepository.DeleteItem(item.ID);
        }

        [Test]
        public void GetAllStoragesUsingStorageRepository()
        {
            List<Storage> check = _storageRepository.GetAllItems();
            for (int i = 0; i < check.Count; i++)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(check[i].Name, Is.EqualTo(_storageRepository.GetAllItems()[i].Name));
                    Assert.That(check[i].Stock, Is.EqualTo(_storageRepository.GetAllItems()[i].Stock));
                    Assert.That(check[i].Price, Is.EqualTo(_storageRepository.GetAllItems()[i].Price));
                    Assert.That(check[i].Description, Is.EqualTo(_storageRepository.GetAllItems()[i].Description));
                    Assert.That(check[i].StorageType, Is.EqualTo(_storageRepository.GetAllItems()[i].StorageType));
                    Assert.That(check[i].StorageSize, Is.EqualTo(_storageRepository.GetAllItems()[i].StorageSize));
                });
            }
        }

        [Test]
        public void AddStorageUsingStorageRepository()
        {
            var check = _storageRepository.AddItem(item);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Name, Is.EqualTo(item.Name));
                Assert.That(check.Stock, Is.EqualTo(item.Stock));
                Assert.That(check.Price, Is.EqualTo(item.Price));
                Assert.That(check.Description, Is.EqualTo(item.Description));
                Assert.That(check.StorageType, Is.EqualTo(item.StorageType));
                Assert.That(check.StorageSize, Is.EqualTo(item.StorageSize));
            });
            _storageRepository.DeleteItem(item.ID);
        }

        [TestCase("test name", 50, 100, "test storage description", "test storage type", 320)]
        [TestCase("TEST NAME", 0, 50.5, "TEST MEMORY DESCRIPTION", "TEST STORAGE TYPE", 500)]
        [TestCase("Test Name123", 10000, 999.99, "Test Storage Description123", "Test Storage Type123", 10000)]
        [TestCase("test name!&*^%4", 1, 0, "test storage description!&*^%4", "test storage type!&*^%4", 3000)]
        public void EditStorageUsingStorageRepository(string testName, int testStock, double testPrice, string testDescription, string testStorageType, int testStorageSize)
        {
            Storage ExampleItem = new(item.ID, testName, item.Type, testStock, testPrice, testDescription, testStorageType, testStorageSize);
            _storageRepository.AddItem(item);

            var check = _storageRepository.EditItem(ExampleItem, item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Name, Is.EqualTo(testName));
                Assert.That(check.Stock, Is.EqualTo(testStock));
                Assert.That(check.Price, Is.EqualTo(testPrice));
                Assert.That(check.Description, Is.EqualTo(testDescription));
                Assert.That(check.StorageType, Is.EqualTo(testStorageType));
                Assert.That(check.StorageSize, Is.EqualTo(testStorageSize));
            });
            _storageRepository.DeleteItem(item.ID);
        }

        [Test]
        public void DeleteStorageUsingStorageRepository()
        {
            _storageRepository.AddItem(item);

            bool check = _storageRepository.DeleteItem(item.ID);

            Assert.That(check, Is.EqualTo(true));
        }
    }
}
