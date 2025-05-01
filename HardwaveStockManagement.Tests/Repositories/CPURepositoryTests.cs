using HardwaveStockManagement.DataManagement;
using HardwaveStockManagement.Models;
using HardwaveStockManagement.Repository;

namespace HardwaveStockManagement.Tests.Repositories
{
    public class CPURepositoryTests
    {
        private readonly CPURepository _cpuRepository;

        public CPURepositoryTests()
        {
            ItemContext context = new();
            _cpuRepository = new(context);
        }

        private CPU item;

        [SetUp]
        public void Setup()
        {
            item = new(Guid.NewGuid(), "test cpu", "cpu", 11, 22.22, "test cpu description", 33, 44, "test socket");
        }

        [Test]
        public void GetIndividualCPUUsingCPURepository()
        {
            _cpuRepository.AddItem(item);

            var check = _cpuRepository.GetItem(item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Name, Is.EqualTo(item.Name));
                Assert.That(check.Stock, Is.EqualTo(item.Stock));
                Assert.That(check.Price, Is.EqualTo(item.Price));
                Assert.That(check.Description, Is.EqualTo(item.Description));
                Assert.That(check.Cores, Is.EqualTo(item.Cores));
                Assert.That(check.ClockSpeed, Is.EqualTo(item.ClockSpeed));
                Assert.That(check.Socket, Is.EqualTo(item.Socket));
            });
            _cpuRepository.DeleteItem(item.ID);
        }

        [Test]
        public void GetAllCPUsUsingCPURepository()
        {
            List<CPU> check = _cpuRepository.GetAllItems();
            for (int i = 0; i < check.Count; i++)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(check[i].Name, Is.EqualTo(_cpuRepository.GetAllItems()[i].Name));
                    Assert.That(check[i].Stock, Is.EqualTo(_cpuRepository.GetAllItems()[i].Stock));
                    Assert.That(check[i].Price, Is.EqualTo(_cpuRepository.GetAllItems()[i].Price));
                    Assert.That(check[i].Description, Is.EqualTo(_cpuRepository.GetAllItems()[i].Description));
                    Assert.That(check[i].Cores, Is.EqualTo(_cpuRepository.GetAllItems()[i].Cores));
                    Assert.That(check[i].ClockSpeed, Is.EqualTo(_cpuRepository.GetAllItems()[i].ClockSpeed));
                    Assert.That(check[i].Socket, Is.EqualTo(_cpuRepository.GetAllItems()[i].Socket));
                });
            }
        }

        [Test]
        public void AddCPUUsingCPURepository()
        {
            var check = _cpuRepository.AddItem(item);

            Assert.Multiple(() =>
            {
                Assert.That(check.Name, Is.EqualTo(item.Name));
                Assert.That(check.Stock, Is.EqualTo(item.Stock));
                Assert.That(check.Price, Is.EqualTo(item.Price));
                Assert.That(check.Description, Is.EqualTo(item.Description));
                Assert.That(check.Cores, Is.EqualTo(item.Cores));
                Assert.That(check.ClockSpeed, Is.EqualTo(item.ClockSpeed));
                Assert.That(check.Socket, Is.EqualTo(item.Socket));
            });
            _cpuRepository.DeleteItem(item.ID);
        }

        [TestCase("test name", 50, 100, "test cpu description", 20, 16.16, "test cpu socket")]
        [TestCase("TEST NAME", 0, 50.5, "TEST CPU DESCRIPTION", 18, 8.8, "TEST CPU SOCKET")]
        [TestCase("Test Name123", 10000, 999.99, "Test CPU Description123", 25, 64.64, "Test CPU Socket123")]
        [TestCase("test name!&*^%4", 1, 0, "test cpu description!&*^%4", 8, 128.128, "test cpu socket!&*^%4")]
        public void EditCPUUsingCPURepository(string testName, int testStock, double testPrice, string testDescription, int testCores, double testClockSpeed, string testSocket)
        {
            CPU ExampleItem = new(item.ID, testName, item.Type, testStock, testPrice, testDescription, testCores, testClockSpeed, testSocket);
            _cpuRepository.AddItem(item);

            var check = _cpuRepository.EditItem(ExampleItem, item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Name, Is.EqualTo(testName));
                Assert.That(check.Stock, Is.EqualTo(testStock));
                Assert.That(check.Price, Is.EqualTo(testPrice));
                Assert.That(check.Description, Is.EqualTo(testDescription));
                Assert.That(check.Cores, Is.EqualTo(testCores));
                Assert.That(check.ClockSpeed, Is.EqualTo(testClockSpeed));
                Assert.That(check.Socket, Is.EqualTo(testSocket));
            });
            _cpuRepository.DeleteItem(item.ID);
        }

        [Test]
        public void DeleteCPUUsingCPURepository()
        {
            _cpuRepository.AddItem(item);

            bool check = _cpuRepository.DeleteItem(item.ID);

            Assert.That(check, Is.EqualTo(true));
        }
    }
}
