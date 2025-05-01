using HardwaveStockManagement.DataManagement;
using HardwaveStockManagement.Models;
using HardwaveStockManagement.Repository;

namespace HardwaveStockManagement.Tests.Repositories
{
    public class GraphicsCardRepositoryTests
    {
        private readonly GraphicsCardRepository _graphicsCardRepository;

        public GraphicsCardRepositoryTests() 
        {
            ItemContext context = new();
            _graphicsCardRepository = new(context);
        }

        private GraphicsCard item;

        [SetUp]
        public void Setup()
        {
            item = new(Guid.NewGuid(), "test graphics card", "graphics card", 11, 22.22, "test graphics card description", 33, 44);
        }

        [Test]
        public void GetIndividualGraphicsCardUsingGraphicsCardRepository()
        {
            _graphicsCardRepository.AddItem(item);

            var check = _graphicsCardRepository.GetItem(item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Name, Is.EqualTo(item.Name));
                Assert.That(check.Stock, Is.EqualTo(item.Stock));
                Assert.That(check.Price, Is.EqualTo(item.Price));
                Assert.That(check.Description, Is.EqualTo(item.Description));
                Assert.That(check.VRAM, Is.EqualTo(item.VRAM));
                Assert.That(check.CudaCores, Is.EqualTo(item.CudaCores));
            });
            _graphicsCardRepository.DeleteItem(item.ID);
        }

        [Test]
        public void GetAllGraphicsCardsUsingGraphicsCardRepository()
        {
            List<GraphicsCard> check = _graphicsCardRepository.GetAllItems();
            for (int i = 0; i < check.Count; i++)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(check[i].Name, Is.EqualTo(_graphicsCardRepository.GetAllItems()[i].Name));
                    Assert.That(check[i].Stock, Is.EqualTo(_graphicsCardRepository.GetAllItems()[i].Stock));
                    Assert.That(check[i].Price, Is.EqualTo(_graphicsCardRepository.GetAllItems()[i].Price));
                    Assert.That(check[i].Description, Is.EqualTo(_graphicsCardRepository.GetAllItems()[i].Description));
                    Assert.That(check[i].VRAM, Is.EqualTo(_graphicsCardRepository.GetAllItems()[i].VRAM));
                    Assert.That(check[i].CudaCores, Is.EqualTo(_graphicsCardRepository.GetAllItems()[i].CudaCores));
                });
            }
        }

        [Test]
        public void AddGraphicsCardUsingGraphicsCardRepository()
        {
            var check = _graphicsCardRepository.AddItem(item);

            Assert.Multiple(() =>
            {
                Assert.That(check.Name, Is.EqualTo(item.Name));
                Assert.That(check.Stock, Is.EqualTo(item.Stock));
                Assert.That(check.Price, Is.EqualTo(item.Price));
                Assert.That(check.Description, Is.EqualTo(item.Description));
                Assert.That(check.VRAM, Is.EqualTo(item.VRAM));
                Assert.That(check.CudaCores, Is.EqualTo(item.CudaCores));
            });
            _graphicsCardRepository.DeleteItem(item.ID);
        }

        [TestCase("test name", 50, 100, "test description", 8, 4)]
        [TestCase("TEST NAME", 0, 50.5, "TEST DESCRIPTION", 10, 6)]
        [TestCase("Test Name123", 10000, 999.99, "Test Description123", 6, 2)]
        [TestCase("test name!&*^%$£", 1, 0, "test description!&*^%$£", 20, 12)]
        public void EditGraphicsCardUsingGraphicsCardRepository(string testName, int testStock, double testPrice, string testDescription, int testVRAM, int testCudaCores)
        {
            GraphicsCard ExampleItem = new(item.ID, testName, item.Type, testStock, testPrice, testDescription, testVRAM, testCudaCores);
            _graphicsCardRepository.AddItem(item);

            var check = _graphicsCardRepository.EditItem(ExampleItem, item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Name, Is.EqualTo(testName));
                Assert.That(check.Stock, Is.EqualTo(testStock));
                Assert.That(check.Price, Is.EqualTo(testPrice));
                Assert.That(check.Description, Is.EqualTo(testDescription));
                Assert.That(check.VRAM, Is.EqualTo(testVRAM));
                Assert.That(check.CudaCores, Is.EqualTo(testCudaCores));
            });
            _graphicsCardRepository.DeleteItem(item.ID);
        }

        [Test]
        public void DeleteGraphicsCardUsingGraphicsCardRepository()
        {
            _graphicsCardRepository.AddItem(item);

            bool check = _graphicsCardRepository.DeleteItem(item.ID);

            Assert.That(check, Is.EqualTo(true));
        }
    }
}
