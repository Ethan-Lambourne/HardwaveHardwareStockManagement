using HardwaveStockManagement.DataManagement;
using HardwaveStockManagement.Models;
using HardwaveStockManagement.Repository;

namespace HardwaveStockManagement.Tests.Repositories
{
    public class MotherboardRepositoryTests
    {
        private readonly MotherboardRepository _motherboardRepository;

        public MotherboardRepositoryTests()
        {
            ItemContext context = new();
            _motherboardRepository = new(context);
        }

        private Motherboard item;

        [SetUp]
        public void Setup()
        {
            item = new(Guid.NewGuid(), "test motherboard", "motherboard", 11, 22.22, "test motherboard description", "test socket", "test form factor");
        }

        [Test]
        public void GetIndividualMotherboardUsingMotherboardRepository()
        {
            _motherboardRepository.AddItem(item);

            var check = _motherboardRepository.GetItem(item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Name, Is.EqualTo(item.Name));
                Assert.That(check.Stock, Is.EqualTo(item.Stock));
                Assert.That(check.Price, Is.EqualTo(item.Price));
                Assert.That(check.Description, Is.EqualTo(item.Description));
                Assert.That(check.Socket, Is.EqualTo(item.Socket));
                Assert.That(check.FormFactor, Is.EqualTo(item.FormFactor));
            });
            _motherboardRepository.DeleteItem(item.ID);
        }

        [Test]
        public void GetAllMotherboardsUsingMotherboardRepository()
        {
            List<Motherboard> check = _motherboardRepository.GetAllItems();
            for (int i = 0; i < check.Count; i++)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(check[i].Name, Is.EqualTo(_motherboardRepository.GetAllItems()[i].Name));
                    Assert.That(check[i].Stock, Is.EqualTo(_motherboardRepository.GetAllItems()[i].Stock));
                    Assert.That(check[i].Price, Is.EqualTo(_motherboardRepository.GetAllItems()[i].Price));
                    Assert.That(check[i].Description, Is.EqualTo(_motherboardRepository.GetAllItems()[i].Description));
                    Assert.That(check[i].Socket, Is.EqualTo(_motherboardRepository.GetAllItems()[i].Socket));
                    Assert.That(check[i].FormFactor, Is.EqualTo(_motherboardRepository.GetAllItems()[i].FormFactor));
                });
            }
        }

        [Test]
        public void AddMotherboardUsingMotherboardRepository()
        {
            var check = _motherboardRepository.AddItem(item);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Name, Is.EqualTo(item.Name));
                Assert.That(check.Stock, Is.EqualTo(item.Stock));
                Assert.That(check.Price, Is.EqualTo(item.Price));
                Assert.That(check.Description, Is.EqualTo(item.Description));
                Assert.That(check.Socket, Is.EqualTo(item.Socket));
                Assert.That(check.FormFactor, Is.EqualTo(item.FormFactor));
            });
            _motherboardRepository.DeleteItem(item.ID);
        }

        [TestCase("test name", 50, 100, "test motherboard description", "test socket", "test form factor")]
        [TestCase("TEST NAME", 0, 50.5, "TEST MEMORY DESCRIPTION", "TEST SOCKET", "TEST FORM FACTOR")]
        [TestCase("Test Name123", 10000, 999.99, "Test Motherboard Description123", "Test Socket123", "Test Form Factor123")]
        [TestCase("test name!&*^%4", 1, 0, "test motherboard description!&*^%4", "test socket!&*^%4", "test form factor!&*^%4")]
        public void EditMotherboardUsingMotherboardRepository(string testName, int testStock, double testPrice, string testDescription, string testSocket, string testFormFactor)
        {
            Motherboard ExampleItem = new(item.ID, testName, item.Type, testStock, testPrice, testDescription, testSocket, testFormFactor);
            _motherboardRepository.AddItem(item);

            var check = _motherboardRepository.EditItem(ExampleItem, item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Name, Is.EqualTo(testName));
                Assert.That(check.Stock, Is.EqualTo(testStock));
                Assert.That(check.Price, Is.EqualTo(testPrice));
                Assert.That(check.Description, Is.EqualTo(testDescription));
                Assert.That(check.Socket, Is.EqualTo(testSocket));
                Assert.That(check.FormFactor, Is.EqualTo(testFormFactor));
            });
            _motherboardRepository.DeleteItem(item.ID);
        }

        [Test]
        public void DeleteMotherboardUsingMotherboardRepository()
        {
            _motherboardRepository.AddItem(item);

            bool check = _motherboardRepository.DeleteItem(item.ID);

            Assert.That(check, Is.EqualTo(true));
        }
    }
}
