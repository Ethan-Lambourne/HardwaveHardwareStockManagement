using HardwaveStockManagement.DataManagement;
using HardwaveStockManagement.Repository;

namespace HardwaveStockManagement.Tests.Repositories
{
    public class MonitorRepositoryTests
    {
        private readonly MonitorRepository _monitorRepository;

        public MonitorRepositoryTests()
        {
            ItemContext context = new();
            _monitorRepository = new(context);
        }

        private Models.Monitor item;

        [SetUp]
        public void Setup()
        {
            item = new(Guid.NewGuid(), "test monitor", "monitor", 11, 22.22, "test monitor description", 44.44, 55);
        }

        [Test]
        public void GetIndividualMonitorUsingMonitorRepository()
        {
            _monitorRepository.AddItem(item);

            var check = _monitorRepository.GetItem(item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Name, Is.EqualTo(item.Name));
                Assert.That(check.Stock, Is.EqualTo(item.Stock));
                Assert.That(check.Price, Is.EqualTo(item.Price));
                Assert.That(check.Description, Is.EqualTo(item.Description));
                Assert.That(check.ScreenSize, Is.EqualTo(item.ScreenSize));
                Assert.That(check.RefreshRate, Is.EqualTo(item.RefreshRate));
            });
            _monitorRepository.DeleteItem(item.ID);
        }

        [Test]
        public void GetAllMonitorsUsingMonitorRepository()
        {
            List<Models.Monitor> check = _monitorRepository.GetAllItems();
            for (int i = 0; i < check.Count; i++)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(check[i].Name, Is.EqualTo(_monitorRepository.GetAllItems()[i].Name));
                    Assert.That(check[i].Stock, Is.EqualTo(_monitorRepository.GetAllItems()[i].Stock));
                    Assert.That(check[i].Price, Is.EqualTo(_monitorRepository.GetAllItems()[i].Price));
                    Assert.That(check[i].Description, Is.EqualTo(_monitorRepository.GetAllItems()[i].Description));
                    Assert.That(check[i].ScreenSize, Is.EqualTo(_monitorRepository.GetAllItems()[i].ScreenSize));
                    Assert.That(check[i].RefreshRate, Is.EqualTo(_monitorRepository.GetAllItems()[i].RefreshRate));
                });
            }
        }

        [Test]
        public void AddMonitorUsingMonitorRepository()
        {
            var check = _monitorRepository.AddItem(item);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Name, Is.EqualTo(item.Name));
                Assert.That(check.Stock, Is.EqualTo(item.Stock));
                Assert.That(check.Price, Is.EqualTo(item.Price));
                Assert.That(check.Description, Is.EqualTo(item.Description));
                Assert.That(check.ScreenSize, Is.EqualTo(item.ScreenSize));
                Assert.That(check.RefreshRate, Is.EqualTo(item.RefreshRate));
            });
            _monitorRepository.DeleteItem(item.ID);
        }

        [TestCase("test name", 50, 100, "test monitor description", 16.16, 3200)]
        [TestCase("TEST NAME", 0, 50.5, "TEST MEMORY DESCRIPTION", 8.8, 4800)]
        [TestCase("Test Name123", 10000, 999.99, "Test Monitor Description123", 64.64, 5400)]
        [TestCase("test name!&*^%4", 1, 0, "test monitor description!&*^%4", 128.128, 9999)]
        public void EditMonitorUsingMonitorRepository(string testName, int testStock, double testPrice, string testDescription, double testScreenSize, int testRefreshRate)
        {
            Models.Monitor ExampleItem = new(item.ID, testName, item.Type, testStock, testPrice, testDescription, testScreenSize, testRefreshRate);
            _monitorRepository.AddItem(item);

            var check = _monitorRepository.EditItem(ExampleItem, item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Name, Is.EqualTo(testName));
                Assert.That(check.Stock, Is.EqualTo(testStock));
                Assert.That(check.Price, Is.EqualTo(testPrice));
                Assert.That(check.Description, Is.EqualTo(testDescription));
                Assert.That(check.ScreenSize, Is.EqualTo(testScreenSize));
                Assert.That(check.RefreshRate, Is.EqualTo(testRefreshRate));
            });
            _monitorRepository.DeleteItem(item.ID);
        }

        [Test]
        public void DeleteMonitorUsingMonitorRepository()
        {
            _monitorRepository.AddItem(item);

            bool check = _monitorRepository.DeleteItem(item.ID);

            Assert.That(check, Is.EqualTo(true));
        }
    }
}
