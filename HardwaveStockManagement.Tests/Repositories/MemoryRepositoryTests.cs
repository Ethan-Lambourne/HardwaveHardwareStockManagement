using HardwaveStockManagement.DataManagement;
using HardwaveStockManagement.Models;
using HardwaveStockManagement.Repository;

namespace HardwaveStockManagement.Tests.Repositories
{
    public class MemoryRepositoryTests
    {
        private readonly MemoryRepository _memoryRepository;

        public MemoryRepositoryTests()
        {
            ItemContext context = new();
            _memoryRepository = new(context);
        }

        private Memory item;

        [SetUp]
        public void Setup()
        {
            item = new(Guid.NewGuid(), "test memory", "memory", 11, 22.22, "test memory description", "test memory type", 44, 55);
        }

        [Test]
        public void GetIndividualMemoryUsingMemoryRepository()
        {
            _memoryRepository.AddItem(item);

            var check = _memoryRepository.GetItem(item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Name, Is.EqualTo(item.Name));
                Assert.That(check.Stock, Is.EqualTo(item.Stock));
                Assert.That(check.Price, Is.EqualTo(item.Price));
                Assert.That(check.Description, Is.EqualTo(item.Description));
                Assert.That(check.MemoryType, Is.EqualTo(item.MemoryType));
                Assert.That(check.MemorySize, Is.EqualTo(item.MemorySize));
                Assert.That(check.MemorySpeed, Is.EqualTo(item.MemorySpeed));
            });
            _memoryRepository.DeleteItem(item.ID);
        }

        [Test]
        public void GetAllMemorysUsingMemoryRepository()
        {
            List<Memory> check = _memoryRepository.GetAllItems();
            for (int i = 0; i < check.Count; i++)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(check[i].Name, Is.EqualTo(_memoryRepository.GetAllItems()[i].Name));
                    Assert.That(check[i].Stock, Is.EqualTo(_memoryRepository.GetAllItems()[i].Stock));
                    Assert.That(check[i].Price, Is.EqualTo(_memoryRepository.GetAllItems()[i].Price));
                    Assert.That(check[i].Description, Is.EqualTo(_memoryRepository.GetAllItems()[i].Description));
                    Assert.That(check[i].MemoryType, Is.EqualTo(_memoryRepository.GetAllItems()[i].MemoryType));
                    Assert.That(check[i].MemorySize, Is.EqualTo(_memoryRepository.GetAllItems()[i].MemorySize));
                    Assert.That(check[i].MemorySpeed, Is.EqualTo(_memoryRepository.GetAllItems()[i].MemorySpeed));
                });
            }
        }

        [Test]
        public void AddMemoryUsingMemoryRepository()
        {
            var check = _memoryRepository.AddItem(item);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Name, Is.EqualTo(item.Name));
                Assert.That(check.Stock, Is.EqualTo(item.Stock));
                Assert.That(check.Price, Is.EqualTo(item.Price));
                Assert.That(check.Description, Is.EqualTo(item.Description));
                Assert.That(check.MemoryType, Is.EqualTo(item.MemoryType));
                Assert.That(check.MemorySize, Is.EqualTo(item.MemorySize));
                Assert.That(check.MemorySpeed, Is.EqualTo(item.MemorySpeed));
            });
            _memoryRepository.DeleteItem(item.ID);
        }

        [TestCase("test name", 50, 100, "test memory description", "test memory type", 16, 3200)]
        [TestCase("TEST NAME", 0, 50.5, "TEST MEMORY DESCRIPTION", "TEST MEMORY TYPE", 8, 4800)]
        [TestCase("Test Name123", 10000, 999.99, "Test Memory Description123", "Test Memory Type123", 64, 5400)]
        [TestCase("test name!&*^%4", 1, 0, "test memory description!&*^%4", "test memory type!&*^%4", 128, 9999)]
        public void EditMemoryUsingMemoryRepository(string testName, int testStock, double testPrice, string testDescription, string testMemoryType, int testMemorySize, int testMemorySpeed)
        {
            Memory ExampleItem = new(item.ID, testName, item.Type, testStock, testPrice, testDescription, testMemoryType, testMemorySize, testMemorySpeed);
            _memoryRepository.AddItem(item);

            var check = _memoryRepository.EditItem(ExampleItem, item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Name, Is.EqualTo(testName));
                Assert.That(check.Stock, Is.EqualTo(testStock));
                Assert.That(check.Price, Is.EqualTo(testPrice));
                Assert.That(check.Description, Is.EqualTo(testDescription));
                Assert.That(check.MemoryType, Is.EqualTo(testMemoryType));
                Assert.That(check.MemorySize, Is.EqualTo(testMemorySize));
                Assert.That(check.MemorySpeed, Is.EqualTo(testMemorySpeed));
            });
            _memoryRepository.DeleteItem(item.ID);
        }

        [Test]
        public void DeleteMemoryUsingMemoryRepository()
        {
            _memoryRepository.AddItem(item);

            bool check = _memoryRepository.DeleteItem(item.ID);

            Assert.That(check, Is.EqualTo(true));
        }
    }
}
