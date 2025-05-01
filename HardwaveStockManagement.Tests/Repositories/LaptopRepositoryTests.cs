using HardwaveStockManagement.DataManagement;
using HardwaveStockManagement.Models;
using HardwaveStockManagement.Repository;

namespace HardwaveStockManagement.Tests.Repositories
{
    public class LaptopRepositoryTests
    {
        private readonly LaptopRepository _laptopRepository;

        public LaptopRepositoryTests() 
        { 
            ItemContext context = new();
            _laptopRepository = new(context);
        }

        private Laptop item;

        [SetUp]
        public void Setup() 
        {
            item = new(Guid.NewGuid(), "test laptop", "laptop", 11, 22.22, "test laptop description", 33.33, 44, 55);
        }

        [Test]
        public void GetIndividualLaptopUsingLaptopRepository()
        {
            _laptopRepository.AddItem(item);

            var check = _laptopRepository.GetItem(item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Name, Is.EqualTo(item.Name));
                Assert.That(check.Stock, Is.EqualTo(item.Stock));
                Assert.That(check.Price, Is.EqualTo(item.Price));
                Assert.That(check.Description, Is.EqualTo(item.Description));
                Assert.That(check.ScreenSize, Is.EqualTo(item.ScreenSize));
                Assert.That(check.RAM, Is.EqualTo(item.RAM));
                Assert.That(check.Storage, Is.EqualTo(item.Storage));
            });
            _laptopRepository.DeleteItem(item.ID);
        }

        [Test]
        public void GetAllLaptopsUsingLaptopRepository()
        {
            List<Laptop> check = _laptopRepository.GetAllItems();
            for (int i = 0; i < check.Count; i++)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(check[i].Name, Is.EqualTo(_laptopRepository.GetAllItems()[i].Name));
                    Assert.That(check[i].Stock, Is.EqualTo(_laptopRepository.GetAllItems()[i].Stock));
                    Assert.That(check[i].Price, Is.EqualTo(_laptopRepository.GetAllItems()[i].Price));
                    Assert.That(check[i].Description, Is.EqualTo(_laptopRepository.GetAllItems()[i].Description));
                    Assert.That(check[i].ScreenSize, Is.EqualTo(_laptopRepository.GetAllItems()[i].ScreenSize));
                    Assert.That(check[i].RAM, Is.EqualTo(_laptopRepository.GetAllItems()[i].RAM));
                    Assert.That(check[i].Storage, Is.EqualTo(_laptopRepository.GetAllItems()[i].Storage));
                });
            }
        }

        [Test]
        public void AddLaptopUsingLaptopRepository()
        {
            var check = _laptopRepository.AddItem(item);

            Assert.Multiple(() =>
            {
                Assert.That(check.Name, Is.EqualTo(item.Name));
                Assert.That(check.Stock, Is.EqualTo(item.Stock));
                Assert.That(check.Price, Is.EqualTo(item.Price));
                Assert.That(check.Description, Is.EqualTo(item.Description));
                Assert.That(check.ScreenSize, Is.EqualTo(item.ScreenSize));
                Assert.That(check.RAM, Is.EqualTo(item.RAM));
                Assert.That(check.Storage, Is.EqualTo(item.Storage));
            });
            _laptopRepository.DeleteItem(item.ID);
        }

        [TestCase("test name", 50, 100, "test laptop description", 20, 16, 500)]
        [TestCase("TEST NAME", 0, 50.5, "TEST LAPTOP DESCRIPTION", 18.5, 8, 1000)]
        [TestCase("Test Name123", 10000, 999.99, "Test Laptop Description123", 25.25, 64, 3000)]
        [TestCase("test name!&*^%4", 1, 0, "test laptop description!&*^%4", 8, 128, 10)]
        public void EditLaptopUsingLaptopRepository(string testName, int testStock, double testPrice, string testDescription, double testScreenSize, int testRAM, int testStorage)
        {
            Laptop ExampleItem = new(item.ID, testName, item.Type, testStock, testPrice, testDescription, testScreenSize, testRAM, testStorage);
            _laptopRepository.AddItem(item);

            var check = _laptopRepository.EditItem(ExampleItem, item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Name, Is.EqualTo(testName));
                Assert.That(check.Stock, Is.EqualTo(testStock));
                Assert.That(check.Price, Is.EqualTo(testPrice));
                Assert.That(check.Description, Is.EqualTo(testDescription));
                Assert.That(check.ScreenSize, Is.EqualTo(testScreenSize));
                Assert.That(check.RAM, Is.EqualTo(testRAM));
                Assert.That(check.Storage, Is.EqualTo(testStorage));
            });
            _laptopRepository.DeleteItem(item.ID);
        }

        [Test]
        public void DeleteLaptopUsingLaptopRepository()
        {
            _laptopRepository.AddItem(item);

            bool check = _laptopRepository.DeleteItem(item.ID);

            Assert.That(check, Is.EqualTo(true));
        }
    }
}
